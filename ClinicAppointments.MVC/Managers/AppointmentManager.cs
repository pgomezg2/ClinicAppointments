using ClinicAppointments.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClinicAppointments.MVC.Managers
{
  public class AppointmentManager : IAppointmentManager
  {
    private readonly Uri _apiBaseAddress;
    private readonly IPatientManager _patientManager;

    public AppointmentManager()
    {
      _apiBaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseAddress"]);
    }

    public AppointmentManager(IPatientManager patientManager)
    {
      _apiBaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseAddress"]);
      _patientManager = patientManager;
    }

    /// <summary>
    /// Get the basic patient information for appointment creation
    /// </summary>
    /// <param name="patientId"></param>
    /// <returns></returns>
    public AppointmentModel GetAppointmentCreationInformation(int patientId)
    {
      AppointmentModel model = new AppointmentModel {
        Patient = _patientManager.GetPatientById(patientId)
      };

      return model;
    }

    public string CreateAppointment(AppointmentModel appointment)
    {
      string responseMessage = string.Empty;

      using (HttpClient clientApi = new HttpClient())
      {
        // Set the baseaddress
        clientApi.BaseAddress = _apiBaseAddress;

        // Set the proper headers
        clientApi.DefaultRequestHeaders.Clear();
        clientApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Set the body
        string body = JsonConvert.SerializeObject(appointment);
        StringContent data = new StringContent(body, Encoding.UTF8, "application/json");

        // Do the request
        Task<HttpResponseMessage> response = clientApi.PostAsync("appointment", data);

        // Check the response code
        if (!response.Result.IsSuccessStatusCode)
        {
          responseMessage = response.Result.ReasonPhrase;
        }
      }

      return responseMessage;

    }
  }
}
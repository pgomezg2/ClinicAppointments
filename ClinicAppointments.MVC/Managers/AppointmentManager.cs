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

    /// <summary>
    /// Creates a new patient appointment
    /// </summary>
    /// <param name="appointment"></param>
    /// <returns></returns>
    public string CreateAppointment(AppointmentModel appointment)
    {
      string responseMessage = string.Empty;

      if (CheckExistingAppointmentDate(appointment.PatientId,appointment.AppointmentDateTime))
      {
        responseMessage = string.Format("Patient already have an appointment for the selected date");
      }
      else
      {
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
      }

      return responseMessage;

    }

    /// <summary>
    /// Gets the list of all appointments for a given patient
    /// </summary>
    /// <param name="patientId"></param>
    /// <returns></returns>
    public IEnumerable<AppointmentModel> GetAppointmentsByPatient(int patientId)
    {
      string strResponse;
      IEnumerable<AppointmentModel> appointments = Enumerable.Empty<AppointmentModel>();

      using (HttpClient clientApi = new HttpClient())
      {
        // Set the baseaddress from settings
        clientApi.BaseAddress = _apiBaseAddress;

        // Set the proper headers
        clientApi.DefaultRequestHeaders.Clear();

        // No specific resource and content needs to be set
        Task<HttpResponseMessage> response = clientApi.GetAsync("appointment/patient/" + patientId);

        if (response.Result.IsSuccessStatusCode)
        {
          strResponse = response.Result.Content.ReadAsStringAsync().Result;
          appointments = JsonConvert.DeserializeObject<List<AppointmentModel>>(strResponse);
        }
      }

      return appointments;
    }

    /// <summary>
    /// Validates if the patient already have an appoinment for a given date
    /// </summary>
    /// <param name="patientId"></param>
    /// <param name="appointmentDate"></param>
    /// <returns></returns>
    private bool CheckExistingAppointmentDate(int patientId, DateTime appointmentDate)
    {
      bool alreadyExist = false;

      List<AppointmentModel> appointments = GetAppointmentsByPatient(patientId).ToList();

      if (appointments.Where(a => a.AppointmentDateTime.Date == appointmentDate.Date).FirstOrDefault() != null)
      {
        alreadyExist = true;
      }

      return alreadyExist;
    }
  }
}
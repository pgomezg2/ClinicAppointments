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
using System.Web.Mvc;

namespace ClinicAppointments.MVC.Managers
{
  public class PatientManager : IPatientManager
  {
    private readonly Uri _apiBaseAddress;

    public PatientManager()
    {
      _apiBaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseAddress"]);
    }

    /// <summary>
    /// Gets the full list of patients
    /// </summary>
    /// <returns></returns>
    public IEnumerable<PatientModel> GetPatients()
    {
      string strResponse;
      IEnumerable<PatientModel> patients = Enumerable.Empty<PatientModel>();

      using (HttpClient clientApi = new HttpClient())
      {
        // Set the baseaddress from settings
        clientApi.BaseAddress = _apiBaseAddress;

        // Set the proper headers
        clientApi.DefaultRequestHeaders.Clear();

        // No specific resource and content needs to be set
        Task<HttpResponseMessage> response = clientApi.GetAsync("patient");

        if (response.Result.IsSuccessStatusCode)
        {
          strResponse = response.Result.Content.ReadAsStringAsync().Result;
          patients = JsonConvert.DeserializeObject<List<PatientModel>>(strResponse);
        }
      }

      return patients;
    }

    /// <summary>
    /// Creates a new patient
    /// </summary>
    /// <param name="patient">Patient deteail information</param>
    /// <returns></returns>
    public string CreatePatient(PatientModel patient)
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
        string body = JsonConvert.SerializeObject(patient);
        StringContent data = new StringContent(body, Encoding.UTF8, "application/json");

        // Do the request
        Task<HttpResponseMessage> response = clientApi.PostAsync("patient", data);

        // Check the response code
        if (!response.Result.IsSuccessStatusCode)
        {
          responseMessage = response.Result.ReasonPhrase;
        }
      }

      return responseMessage;
    }

    /// <summary>
    /// Gets the specific patient details for a given identification
    /// </summary>
    /// <param name="identification"></param>
    /// <returns></returns>
    public PatientModel GetPatientByIdentification(string identification)
    {
      PatientModel patient = new PatientModel();

      using (HttpClient clientApi = new HttpClient())
      {
        // Set the baseaddress from settings
        clientApi.BaseAddress = _apiBaseAddress;

        // Set the proper headers
        clientApi.DefaultRequestHeaders.Clear();

        // No specific resource and content needs to be set
        Task<HttpResponseMessage> response = clientApi.GetAsync("patient");

        if (response.Result.IsSuccessStatusCode)
        {
          patient = JsonConvert.DeserializeObject<PatientModel>(response.Result.Content.ReadAsStringAsync().Result);
        }
      }

      return patient;
    }

    /// <summary>
    /// Gets the specific patient details for a given identification
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public PatientModel GetPatientById(int id)
    {
      PatientModel patient = new PatientModel();

      using (HttpClient clientApi = new HttpClient())
      {
        // Set the baseaddress from settings
        clientApi.BaseAddress = _apiBaseAddress;

        // Set the proper headers
        clientApi.DefaultRequestHeaders.Clear();

        // No specific resource and content needs to be set
        Task<HttpResponseMessage> response = clientApi.GetAsync(string.Format("patient/{0}",id));

        if (response.Result.IsSuccessStatusCode)
        {
          patient = JsonConvert.DeserializeObject<PatientModel>(response.Result.Content.ReadAsStringAsync().Result);
        }
      }

      return patient;
    }


  }
}
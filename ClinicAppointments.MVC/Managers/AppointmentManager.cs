using ClinicAppointments.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
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
  }
}
using ClinicAppointments.MVC.Models;
using System.Collections.Generic;

namespace ClinicAppointments.MVC.Managers
{
  public interface IAppointmentManager
  {
    /// <summary>
    /// Get the basic patient information for appointment creation
    /// </summary>
    /// <param name="patientId"></param>
    /// <returns></returns>
    AppointmentModel GetAppointmentCreationInformation(int patientId);
  }
}

using ClinicAppointments.MVC.Models;
using System.Collections.Generic;

namespace ClinicAppointments.MVC.Managers
{
  public interface IAppointmentManager
  {
    AppointmentModel GetAppointmentCreationInformation(int patientId);

    string CreateAppointment(AppointmentModel appointment);

    IEnumerable<AppointmentModel> GetAppointmentsByPatient(int patientId);
  }
}

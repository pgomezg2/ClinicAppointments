using ClinicAppointments.MVC.Models;
using System.Collections.Generic;

namespace ClinicAppointments.MVC.Managers
{
  public interface IPatientManager
  {
    IEnumerable<PatientModel> GetPatients();
    string CreatePatient(PatientModel patient);
    PatientModel GetPatientById(int id);
    PatientModel GetPatientByIdentification(string identification);
  }
}

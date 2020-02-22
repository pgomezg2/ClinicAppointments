using ClinicAppointments.SQL;
using System.Linq;

namespace ClinicAppointments.Repository.Interfaces
{
  public interface IPatientRepository : IGenericRepository<Patients>
  {
    IQueryable<Patients> GetPatients();
    Patients GetPatientsById(int id);
    Patients GetPatientsByIdentification(string identification);
  }
}

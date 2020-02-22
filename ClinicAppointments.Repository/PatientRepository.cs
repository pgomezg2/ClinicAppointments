using ClinicAppointments.SQL;
using ClinicAppointments.Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointments.Repository
{
  public class PatientRepository : GenericRepository<Patients>, IPatientRepository
  {
    public PatientRepository()
    {

    }

    public IQueryable<Patients> GetPatients()
    {
      return _context.Patients.AsQueryable();
    }

    public Patients GetPatientsById(int id)
    {
      return _context.Patients.Find(id);
    }

    public Patients GetPatientsByIdentification(string identification)
    {
      return _context.Patients.Where(p => p.Identification == identification).FirstOrDefault();
    }
  }
}

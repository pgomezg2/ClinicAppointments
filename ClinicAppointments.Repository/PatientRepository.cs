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
      return _context.Patients.Include("Appointments.Specialties").Where(p => p.Id == id).FirstOrDefault();
    }

    public Patients GetPatientsByIdentification(string identification)
    {
      return _context.Patients.Include("Appointments.Specialties").Where(p => p.Identification == identification).FirstOrDefault();
    }
  }
}

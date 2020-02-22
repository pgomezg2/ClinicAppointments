using ClinicAppointments.Repository.Interfaces;
using ClinicAppointments.SQL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointments.Repository
{
  public class AppointmentRepository : GenericRepository<Appointments>, IAppointmentRepository
  {
    public AppointmentRepository()
    {

    }

    public IQueryable<Appointments> GetAppointments()
    {
      return _context.Appointments.AsQueryable();
    }

    public IQueryable<Appointments> GetAppointmentsByPatient(int patientId)
    {
      return _context.Appointments.Include("Specialties").Where(a => a.PatientId == patientId);
    }

  }
}

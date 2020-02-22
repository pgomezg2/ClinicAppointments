using ClinicAppointments.SQL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointments.Repository.Interfaces
{
  public interface IAppointmentRepository : IGenericRepository<Appointments>
  {
    IQueryable<Appointments> GetAppointments();
    IQueryable<Appointments> GetAppointmentsByPatient(int id);
  }
}

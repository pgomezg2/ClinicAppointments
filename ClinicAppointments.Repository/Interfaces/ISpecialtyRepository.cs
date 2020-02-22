using ClinicAppointments.SQL;

using ClinicAppointments.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointments.Repository.Interfaces
{
  public interface ISpecialtyRepository : IGenericRepository<Specialties>
  {
    IQueryable<Specialties> GetSpecialties();
    Specialties GetSpecialtiesById(int id);
  }
}

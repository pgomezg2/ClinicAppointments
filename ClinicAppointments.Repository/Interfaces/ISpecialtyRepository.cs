using ClinicAppointments.SQL;
using System.Linq;

namespace ClinicAppointments.Repository.Interfaces
{
  public interface ISpecialtyRepository : IGenericRepository<Specialties>
  {
    IQueryable<Specialties> GetSpecialties();
    Specialties GetSpecialtiesById(int id);
  }
}

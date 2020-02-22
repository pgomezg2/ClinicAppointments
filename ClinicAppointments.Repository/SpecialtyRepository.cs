using AutoMapper;

using ClinicAppointments.Domain;
using ClinicAppointments.Repository.Interfaces;
using ClinicAppointments.SQL;
using System.Collections.Generic;
using System.Linq;

namespace ClinicAppointments.Repository
{
  public class SpecialtyRepository : GenericRepository<Specialties>, ISpecialtyRepository
  {
    public SpecialtyRepository()
    {

    }

    public IQueryable<Specialties> GetSpecialties()
    {
      return _context.Specialties.AsQueryable();
    }

    public Specialties GetSpecialtiesById(int id)
    {
      return _context.Specialties.Find(id);
    }
  }
}

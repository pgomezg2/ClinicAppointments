using ClinicAppointments.Domain;
using ClinicAppointments.Repository;
using ClinicAppointments.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ClinicAppointments.API.Helper
{
  public class SpecialtyHelper
  {
    private ISpecialtyRepository _specialtyRepository;

    public SpecialtyHelper()
    {
      _specialtyRepository = new SpecialtyRepository();
    }

    /// <summary>
    /// Get the full list of specialties
    /// </summary>
    /// <returns></returns>
    public List<Specialty> GetSpecialties()
    {
      List<SQL.Specialties> spDb = _specialtyRepository.GetAll().ToList();

      List<Specialty> spDom = new List<Specialty>();

      foreach (SQL.Specialties sp in spDb)
      {
        spDom.Add(new Specialty { Id = sp.Id, SpecialtyName = sp.SpecialtyName });
      }

      return spDom;
    }

    /// <summary>
    /// Get an specific specialty
    /// </summary>
    /// <param name="id">Specialty id</param>
    /// <returns></returns>
    public Specialty GetSpecialtyById(int id)
    {
      SQL.Specialties spDb = _specialtyRepository.GetSpecialtiesById(id);

      if (spDb != null)
      {
        Specialty sp = new Specialty
        {
          Id = spDb.Id,
          SpecialtyName = spDb.SpecialtyName
        };

        return sp;
      }
      else
      {
        return new Specialty();
      }
    }
  }
}
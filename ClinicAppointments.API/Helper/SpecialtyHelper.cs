using ClinicAppointments.Domain;
using ClinicAppointments.Repository;
using ClinicAppointments.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicAppointments.API.Helper
{
  public class SpecialtyHelper : ISpecialtyHelper
  {
    private ISpecialtyRepository _specialtyRepository;

    public SpecialtyHelper()
    {
      _specialtyRepository = new SpecialtyRepository();
    }

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
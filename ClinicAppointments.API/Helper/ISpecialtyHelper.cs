using ClinicAppointments.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointments.API.Helper
{
  public interface ISpecialtyHelper
  {
    List<Specialty> GetSpecialties();
    Specialty GetSpecialtyById(int id);
  }
}

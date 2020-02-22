using ClinicAppointments.SQL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointments.Repository.Interfaces
{
  public interface IGenericRepository<T> where T : class
  {
    IEnumerable<T> GetAll();

    T GetById(object id);
  }
}

using AutoMapper;

using ClinicAppointments.SQL;
using ClinicAppointments.Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointments.Repository
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    protected ClinicDB _context = new ClinicDB();
    protected DbSet<T> Dbset = null;

    public GenericRepository()
    {
      _context = new ClinicDB();
      Dbset = _context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
      return Dbset.AsQueryable();
    }

    public T GetById(object id)
    {
      return Dbset.Find(id);
    }
  }
}

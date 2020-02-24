using ClinicAppointments.API.Models;
using ClinicAppointments.Domain;
using ClinicAppointments.Repository;
using ClinicAppointments.Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicAppointments.API.Helper
{
  public class PatientHelper
  {
    private readonly IPatientRepository _patientRepository;

    public PatientHelper()
    {
      _patientRepository = new PatientRepository();
    }

    /// <summary>
    /// Get the full list of patients
    /// </summary>
    /// <returns></returns>
    public List<Patient> GetPatients()
    {
      List<Patient> patients = new List<Patient>();
      List<SQL.Patients> ptDB = _patientRepository.GetPatients().ToList();

      foreach (SQL.Patients pt in ptDB)
      {
        patients.Add(new Patient
        {
          Id = pt.Id,
          Identification = pt.Identification,
          FirstName = pt.FirstName,
          LastName = pt.LastName,
          Age = 0,
          PhoneNumber = pt.PhoneNumber,
          Email = pt.Email
        });
      }

      return patients;
    }

    /// <summary>
    /// Get patient details by a given id
    /// </summary>
    /// <param name="id">Patient id</param>
    /// <returns></returns>
    public Patient GetPatientById(int id)
    {
      SQL.Patients ptDb = _patientRepository.GetPatientsById(id);

      if (ptDb != null)
      {
        Patient pt = new Patient
        {
          Id = ptDb.Id,
          Identification = ptDb.Identification,
          FirstName = ptDb.FirstName,
          LastName = ptDb.LastName,
          Age = 0,
          PhoneNumber = ptDb.PhoneNumber,
          Email = ptDb.Email,
          Appointments = Enumerable.Empty<Appointment>().ToList()
        };

        foreach (SQL.Appointments item in ptDb.Appointments)
        {
          pt.Appointments.Add(new Appointment
          {
            Id = item.Id,
            PatientId = item.PatientId,
            SpecialtyId = item.SpecialtyId,
            AppointmentDateTime = item.AppointmentDateTime,
            Specialty = new Specialty
            {
              Id = item.Specialties.Id,
              SpecialtyName = item.Specialties.SpecialtyName
            }
          });
        }

        return pt;
      }
      else
      {
        return new Patient();
      }
    }

    /// <summary>
    /// Get patient details by a given id
    /// </summary>
    /// <param name="identification">Patient identification</param>
    /// <returns></returns>
    public Patient GetPatientByIdentification(string identification)
    {
      SQL.Patients ptDb = _patientRepository.GetPatientsByIdentification(identification);

      if (ptDb != null)
      {
        Patient pt = new Patient
        {
          Id = ptDb.Id,
          Identification = ptDb.Identification,
          FirstName = ptDb.FirstName,
          LastName = ptDb.LastName,
          Age = ptDb.Age.GetValueOrDefault(),
          PhoneNumber = ptDb.PhoneNumber,
          Email = ptDb.Email,
          Appointments = Enumerable.Empty<Appointment>().ToList()
        };

        foreach (SQL.Appointments item in ptDb.Appointments)
        {
          pt.Appointments.Add(new Appointment
          {
            Id = item.Id,
            PatientId = item.PatientId,
            SpecialtyId = item.SpecialtyId,
            AppointmentDateTime = item.AppointmentDateTime,
            Specialty = new Specialty
            {
              Id = item.Specialties.Id,
              SpecialtyName = item.Specialties.SpecialtyName
            }
          });
        }

        return pt;
      }
      else
      {
        return new Patient();
      }
    }

    /// <summary>
    /// Creates a new patience
    /// </summary>
    /// <param name="model">Patient information detail</param>
    /// <returns></returns>
    public bool CreatePatient(PatientModel model)
    {
      bool isCreated = true;

      SQL.Patients ptDB = new SQL.Patients
      {
        Identification = model.Identification,
        FirstName = model.FirstName,
        LastName = model.LastName,
        Age = model.Age,
        PhoneNumber = model.PhoneNumber,
        Email = model.Email
      };

      _patientRepository.Insert(ptDB);
      _patientRepository.Save();

      return isCreated;
    }
  }
}
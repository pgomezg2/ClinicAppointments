using ClinicAppointments.Domain;
using ClinicAppointments.API.Models;
using ClinicAppointments.Repository;
using ClinicAppointments.Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicAppointments.API.Helper
{
  public class AppointmentHelper
  {
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentHelper()
    {
      _appointmentRepository = new AppointmentRepository();
    }

    /// <summary>
    /// Gets the full list of appointments
    /// </summary>
    /// <returns></returns>
    public List<Appointment> GetAppointments()
    {
      List<Appointment> appointments = new List<Appointment>();
      List<SQL.Appointments> appDB = _appointmentRepository.GetAppointments().ToList();

      foreach (SQL.Appointments app in appDB)
      {
        appointments.Add(new Appointment
        {
          Id = app.Id,
          PatientId = app.PatientId,
          SpecialtyId = app.SpecialtyId,
          AppointmentDateTime = app.AppointmentDateTime,
          Specialty = new Specialty
          {
            Id = app.Specialties.Id,
            SpecialtyName = app.Specialties.SpecialtyName
          },
          Patient = new Patient
          {
            Id = app.Patients.Id,
            Identification = app.Patients.Identification,
            FirstName = app.Patients.FirstName,
            LastName = app.Patients.LastName,
            Age = app.Patients.Age.GetValueOrDefault(),
            PhoneNumber = app.Patients.PhoneNumber,
            Email = app.Patients.Email
          }
        });
      }

      return appointments;
    }

    /// <summary>
    /// Gets the list of appointments for a given patient 
    /// </summary>
    /// <param name="patientId">Patient id</param>
    /// <returns></returns>
    public List<Appointment> GetAppointmentsByPatient(int patientId)
    {
      List<Appointment> appointments = new List<Appointment>();
      List<SQL.Appointments> appDB = _appointmentRepository.GetAppointmentsByPatient(patientId).ToList();

      foreach (SQL.Appointments app in appDB)
      {
        appointments.Add(new Appointment
        {
          Id = app.Id,
          PatientId = app.PatientId,
          SpecialtyId = app.SpecialtyId,
          AppointmentDateTime = app.AppointmentDateTime,
          Specialty = new Specialty
          {
            Id = app.Specialties.Id,
            SpecialtyName = app.Specialties.SpecialtyName
          }
        });
      }

      return appointments;
    }

    /// <summary>
    /// Creates a new appointment for an specific patient
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public bool CreateAppointment(AppointmentModel model)
    {
      bool isCreated = true;

      SQL.Appointments appDB = new SQL.Appointments
      {
        PatientId = model.PatientId,
        SpecialtyId = model.SpecialtyId,
        AppointmentDateTime = model.AppointmentDateTime
      };

      _appointmentRepository.Insert(appDB);
      _appointmentRepository.Save();

      return isCreated;
    }

    /// <summary>
    /// Deletes an specific appointment
    /// </summary>
    /// <param name="id">Appointment id</param>
    public void DeleteAppointment(int id)
    {
      _appointmentRepository.Delete(id);
      _appointmentRepository.Save();
    }
  }
}
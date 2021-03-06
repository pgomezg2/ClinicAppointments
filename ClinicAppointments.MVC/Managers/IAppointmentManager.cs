﻿using ClinicAppointments.MVC.Models;
using System.Collections.Generic;

namespace ClinicAppointments.MVC.Managers
{
  public interface IAppointmentManager
  {
    IEnumerable<AppointmentModel> GetAppointments();

    AppointmentModel GetAppointmentCreationInformation(int patientId);

    string CreateAppointment(AppointmentModel appointment);

    IEnumerable<AppointmentModel> GetAppointmentsByPatient(int patientId);
  }
}

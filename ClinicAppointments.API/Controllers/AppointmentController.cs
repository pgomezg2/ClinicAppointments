using ClinicAppointments.API.Helper;
using ClinicAppointments.API.Models;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ClinicAppointments.API.Controllers
{
  [RoutePrefix("api/appointment")]
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class AppointmentController : ApiController
  {
    private readonly AppointmentHelper _appointmentHelper;

    public AppointmentController()
    {
      _appointmentHelper = new AppointmentHelper();
    }

    [HttpGet]
    public IHttpActionResult GetAppointments()
    {
      return Ok(_appointmentHelper.GetAppointments());
    }

    [HttpGet]
    [Route("Patient/{patientId}")]
    public IHttpActionResult GetAppointmentsByPatient(int patientId)
    {
      return Ok(_appointmentHelper.GetAppointmentsByPatient(patientId));
    }

    [HttpPost]
    public IHttpActionResult CreateAppointment(AppointmentModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      // Check if the patient already have one appointment for the given date 
      Domain.Appointment appointment = _appointmentHelper.GetAppointmentsByPatient(model.PatientId).Where(a => a.AppointmentDateTime.Date == model.AppointmentDateTime.Date).FirstOrDefault();

      // No appointments for the given date
      if (appointment == null)
      {
        _appointmentHelper.CreateAppointment(model);
        return Ok("Success");
      }
      else
      {
        return Ok(string.Format("You already have an appointment for {0}", model.AppointmentDateTime.ToString("yyyy-MM-dd")));
      }

    }

    [HttpDelete]
    public IHttpActionResult DeleteAppointment(int id)
    {
      // Get the maximum cancellation hours
      int maxHoursCancellation = Convert.ToInt16(ConfigurationManager.AppSettings["MaxHoursCancellation"]);

      // Get the appointment detail
      Domain.Appointment appointment = _appointmentHelper.GetAppointments().Where(a => a.Id == id).FirstOrDefault();

      // Check status for the result
      if (appointment == null)
      {
        return Ok(string.Format("The appointment does not exist."));
      }
      else if ((appointment.AppointmentDateTime - DateTime.Now).TotalHours < maxHoursCancellation)
      {
        return Ok(string.Format("Appointments cannot be canceled less than {0} hours in advance.",maxHoursCancellation));
      }
      else
      {
        _appointmentHelper.DeleteAppointment(id);
        return Ok("Success");
      }
    }
  }
}

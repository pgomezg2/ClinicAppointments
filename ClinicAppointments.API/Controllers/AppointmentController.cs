using ClinicAppointments.API.Helper;
using ClinicAppointments.API.Models;

using System;
using System.Collections.Generic;
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

      _appointmentHelper.CreateAppointment(model);

      return Ok();
    }

    [HttpDelete]
    public IHttpActionResult DeleteAppointment(int id)
    {
      _appointmentHelper.DeleteAppointment(id);
      return Ok();
    }
  }
}

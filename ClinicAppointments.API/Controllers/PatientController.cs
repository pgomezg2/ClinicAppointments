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
  [RoutePrefix("api/patient")]
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class PatientController : ApiController
  {
    readonly PatientHelper _patientHelper;

    public PatientController()
    {
      _patientHelper = new PatientHelper();
    }

    [HttpGet]
    public IHttpActionResult Get()
    {
      return Ok(_patientHelper.GetPatients());
    }

    [HttpGet]
    public IHttpActionResult GetPatientById(int id)
    {
      return Ok(_patientHelper.GetPatientById(id));
    }

    [HttpGet]
    [Route("identification/{identification}")]
    public IHttpActionResult GetPatientByIdentification(string identification)
    {
      return Ok(_patientHelper.GetPatientByIdentification(identification));
    }

    [HttpPost]
    public IHttpActionResult CreatePatient(PatientModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _patientHelper.CreatePatient(model);

      return Ok();
    }
  }
}

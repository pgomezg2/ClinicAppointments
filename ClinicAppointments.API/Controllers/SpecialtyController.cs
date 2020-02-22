using System.Web.Http;

using ClinicAppointments.API.Helper;

namespace ClinicAppointments.API.Controllers
{
  public class SpecialtyController : ApiController
  {
    SpecialtyHelper _spHelper;

    public SpecialtyController()
    {
      _spHelper = new SpecialtyHelper();
    }

    [HttpGet]
    public IHttpActionResult Get()
    {
      return Ok(_spHelper.GetSpecialties());
    }

    public IHttpActionResult GetSpecialtyById(int id)
    {
      return Ok(_spHelper.GetSpecialtyById(id));
    }
  }
}

using System.Web.Http;
using System.Web.Http.Cors;
using ClinicAppointments.API.Helper;

namespace ClinicAppointments.API.Controllers
{
  [RoutePrefix("api/specialty")]
  [EnableCors(origins: "*", headers: "*", methods: "*")]
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

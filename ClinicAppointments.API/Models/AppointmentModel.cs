using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicAppointments.API.Models
{
  public class AppointmentModel
  {
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int SpecialtyId { get; set; }
    public DateTime AppointmentDateTime { get; set; }

    public SpecialtyModel Specialty { get; set; }
  }
}
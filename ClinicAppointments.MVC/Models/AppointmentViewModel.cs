using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicAppointments.MVC.Models
{
  public class AppointmentModel
  {
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int SpecialtyId { get; set; }

    [DisplayName("Appointment Date")]
    public DateTime AppointmentDateTime { get; set; }

    public PatientModel Patient { get; set; }
    public SpecialtyModel Specialty { get; set; }
  }
}
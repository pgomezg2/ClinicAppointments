using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ClinicAppointments.MVC.Models
{
  public class SpecialtyModel
  {
    public int Id { get; set; }

    [DisplayName("Specialty")]
    public string SpecialtyName { get; set; }
  }
}
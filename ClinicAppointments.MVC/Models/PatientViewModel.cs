using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ClinicAppointments.MVC.Models
{
  public class PatientModel
  {
    public PatientModel()
    {
      Appointments = new List<AppointmentModel>();
    }

    public int Id { get; set; }

    [DisplayName("Identification")]
    public string Identification { get; set; }

    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [DisplayName("Age")]
    public int Age { get; set; }

    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; }

    [DisplayName("Email")]
    public string Email { get; set; }

    public List<AppointmentModel> Appointments { get; set; }
  }
}
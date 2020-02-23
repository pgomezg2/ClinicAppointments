﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicAppointments.MVC.Models
{
  public class PatientViewModel
  {
    public int Id { get; set; }
    public string Identification { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
  }
}
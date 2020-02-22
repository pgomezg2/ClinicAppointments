using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointments.Domain
{
  public class Appointment
  {
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int SpecialtyId { get; set; }
    public DateTime AppointmentDateTime { get; set; }

    public Specialty Specialty { get; set; }
  }
}

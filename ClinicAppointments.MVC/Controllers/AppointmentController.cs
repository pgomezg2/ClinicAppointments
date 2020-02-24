using System;
using System.Web.Mvc;

using ClinicAppointments.MVC.Managers;
using ClinicAppointments.MVC.Models;

namespace ClinicAppointments.MVC.Controllers
{
  public class AppointmentController : Controller
  {
    private readonly AppointmentManager _appointmentManager;

    public AppointmentController()
    {
      _appointmentManager = new AppointmentManager(new PatientManager());
    }
    
    // GET: Appointment
    public ActionResult Index()
    {
      return View(_appointmentManager.GetAppointments());
    }

    // GET: Appointment/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // POST: Appointment/Create
    [HttpGet]
    public ActionResult Create(int id)
    {
      return View(_appointmentManager.GetAppointmentCreationInformation(id));
    }

    // POST: Appointment/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
      try
      {
        string strDateTimeSelected = string.Format("{0} {1}", collection["dateSelected"], collection["timeSelected"]);

        DateTime.TryParse(strDateTimeSelected, out DateTime dateTimeSelected);

        // TODO: Add insert logic here
        AppointmentModel appointment = new AppointmentModel
        {
          PatientId = Convert.ToInt16(collection["patient.Id"]),
          SpecialtyId = Convert.ToInt16(collection["specialtyId"]),
          AppointmentDateTime = dateTimeSelected
        };

        string msg = _appointmentManager.CreateAppointment(appointment);

        if (!string.IsNullOrEmpty(msg))
        {
          ViewBag.ErrorDateExist = msg;
        }

        return RedirectToAction("Create", "Appointment", new { id = appointment.PatientId });
      }
      catch
      {
        return View();
      }
    }

    // GET: Appointment/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: Appointment/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add update logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    // GET: Appointment/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Appointment/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add delete logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }
  }
}

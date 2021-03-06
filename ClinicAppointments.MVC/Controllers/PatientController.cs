﻿using System;
using System.Web.Mvc;

using ClinicAppointments.MVC.Managers;
using ClinicAppointments.MVC.Models;

namespace ClinicAppointments.MVC.Controllers
{
  public class PatientController : Controller
  {
    private readonly PatientManager _patientManager;

    public PatientController()
    {
      _patientManager = new PatientManager();
    }

    // GET: Patient
    public ActionResult Index()
    {
      return View(_patientManager.GetPatients());
    }

    // GET: Patient/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: Patient/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Patient/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
      try
      {
        // Get the patient detail
        PatientModel patient = new PatientModel
        {
          Identification = collection["Identification"],
          FirstName = collection["FirstName"],
          LastName = collection["LastName"],
          Age = Convert.ToInt16(collection["Age"]),
          PhoneNumber = collection["PhoneNumber"],
          Email = collection["Email"]
        };

        string msg = _patientManager.CreatePatient(patient);

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    // GET: Patient/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: Patient/Edit/5
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

    // GET: Patient/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Patient/Delete/5
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

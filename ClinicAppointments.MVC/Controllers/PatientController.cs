using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

using Newtonsoft.Json;

using ClinicAppointments.MVC.Models;
using System.Net.Http.Headers;
using System.Text;

namespace ClinicAppointments.MVC.Controllers
{
  public class PatientController : Controller
  {
    private readonly Uri _apiBaseAddress;

    public PatientController()
    {
      _apiBaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseAddress"]);
    }

    // GET: Patient
    public ActionResult Index()
    {
      string strResponse;
      IEnumerable<PatientViewModel> patients = null;

      using (HttpClient clientApi = new HttpClient())
      {
        // Set the baseaddress from settings
        clientApi.BaseAddress = _apiBaseAddress;

        // Set the proper headers
        clientApi.DefaultRequestHeaders.Clear();

        // No specific resource and content needs to be set
        Task<HttpResponseMessage> response = clientApi.GetAsync("patient");

        if (response.Result.IsSuccessStatusCode)
        {
          strResponse = response.Result.Content.ReadAsStringAsync().Result;
          patients = JsonConvert.DeserializeObject<List<PatientViewModel>>(strResponse);
        }
        else
        {
          patients = Enumerable.Empty<PatientViewModel>();

          ModelState.AddModelError(string.Empty, "Server error. Please contact administrator");
        }
      }

      return View(patients);
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
        // TODO: Add insert logic here
        PatientViewModel model = new PatientViewModel
        {
          Identification = collection["Identification"],
          FirstName = collection["FirstName"],
          LastName = collection["LastName"],
          Age = Convert.ToInt16(collection["Age"]),
          PhoneNumber = collection["PhoneNumber"],
          Email = collection["Email"]
        };

        using (HttpClient clientApi = new HttpClient())
        {
          // Set the baseaddress from settings
          clientApi.BaseAddress = _apiBaseAddress;

          // Set the proper headers
          clientApi.DefaultRequestHeaders.Clear();
          clientApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

          // Set the body
          string body = JsonConvert.SerializeObject(model);
          StringContent data = new StringContent(body, Encoding.UTF8, "application/json");

          // No specific resource and content needs to be set
          Task<HttpResponseMessage> response = clientApi.PostAsync("patient", data);

          if (!response.Result.IsSuccessStatusCode)
          {
            ModelState.AddModelError(string.Empty, response.Result.ReasonPhrase);
          }
        }

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

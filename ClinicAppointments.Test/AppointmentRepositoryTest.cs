using ClinicAppointments.Repository;
using ClinicAppointments.Repository.Interfaces;
using ClinicAppointments.MVC.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointments.Test
{
  /// <summary>
  /// Summary description for AppointmentRepositoryTest
  /// </summary>
  [TestClass]
  public class AppointmentRepositoryTest
  {
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentRepositoryTest()
    {
      _appointmentRepository = new AppointmentRepository();
    }

    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    //
    // You can use the following additional attributes as you write your tests:
    //
    // Use ClassInitialize to run code before running the first test in the class
    // [ClassInitialize()]
    // public static void MyClassInitialize(TestContext testContext) { }
    //
    // Use ClassCleanup to run code after all tests in a class have run
    // [ClassCleanup()]
    // public static void MyClassCleanup() { }
    //
    // Use TestInitialize to run code before running each test 
    // [TestInitialize()]
    // public void MyTestInitialize() { }
    //
    // Use TestCleanup to run code after each test has run
    // [TestCleanup()]
    // public void MyTestCleanup() { }
    //
    #endregion

    [DataTestMethod]
    [DataRow(7, 3, "2020-03-01 14:00")]
    [DataRow(7, 1, "2020-03-05 09:00")]
    public void Test_CreateAppointment_Success(int patientId, int specialtyId, string appointmentDateTime)
    {

      SQL.Appointments appointment = new SQL.Appointments
      {
        PatientId = patientId,
        SpecialtyId = specialtyId,
        AppointmentDateTime = Convert.ToDateTime(appointmentDateTime)
      };

      _appointmentRepository.Insert(appointment);
      _appointmentRepository.Save();

      Assert.IsTrue(appointment.Id > 0);
    }

    [DataTestMethod]
    [DataRow(7, 1, "2020-03-05 09:00")]
    public void Test_SameDateAppointment_Error(int patientId, int specialtyId, string appointmentDateTime)
    {
      Uri _apiBaseAddress = new Uri("http://local.clinicappointmentsapi.com/api/");
      string responseMessage = string.Empty;

      AppointmentModel appointment = new AppointmentModel
      {
        PatientId = patientId,
        SpecialtyId = specialtyId,
        AppointmentDateTime = Convert.ToDateTime(appointmentDateTime)
      };

      using (HttpClient clientApi = new HttpClient())
      {
        // Set the baseaddress
        clientApi.BaseAddress = _apiBaseAddress;

        // Set the proper headers
        clientApi.DefaultRequestHeaders.Clear();
        clientApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Set the body
        string body = JsonConvert.SerializeObject(appointment);
        StringContent data = new StringContent(body, Encoding.UTF8, "application/json");

        // Do the request
        Task<HttpResponseMessage> response = clientApi.PostAsync("appointment", data);

        // Check the response code
        if (!response.Result.IsSuccessStatusCode)
        {
          responseMessage = response.Result.ReasonPhrase;
        }
      }

      Assert.IsFalse(responseMessage.Equals("Success"));
    }
  }
}

using ClinicAppointments.Repository;
using ClinicAppointments.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClinicAppointments.Test
{
  [TestClass]
  public class PatientRepositoryTest
  {
    private readonly IPatientRepository _patientRepository;

    public PatientRepositoryTest()
    {
      _patientRepository = new PatientRepository();
    }

    [DataTestMethod]
    [DataRow("123456", "John", "Doe", 30, "john.doe@email.com", "5553698")]
    [DataRow("789654", "Jane", "Doe", 25, "jane.doe@email.com", "5551478")]
    public void Test_CreatePatient_Success(string Identification, string FirstName, string LastName, int Age, string Email, string PhoneNumber)
    {
      SQL.Patients patient = new SQL.Patients
      {
        Identification = Identification,
        FirstName = FirstName,
        LastName = LastName,
        Age = Age,
        Email = Email,
        PhoneNumber = PhoneNumber
      };

      _patientRepository.Insert(patient);
      _patientRepository.Save();

      Assert.IsTrue(patient.Id > 0);
    }
  }
}

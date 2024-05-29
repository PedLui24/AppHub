using AppHub.Domain.Exceptions;
using AppHub.Domain.Models;

namespace AppHub.Domain.Test;

[TestClass]
public class PersonModelTest
{
    [TestMethod]
    public void ValidCreatePersonModel()
    {
        Guid id = Guid.NewGuid();
        string name = "Pedro";
        string lastname = "Tarqui";
        string email = "pedro.tarqui@uab.edu.bo";
        string phoneNumber = "74903140";
        DateTime birthdate = new DateTime(2001, 02, 18);

        PersonModel result = new PersonModel(id, name, lastname, email, phoneNumber, birthdate);
        
        Assert.IsNotNull(result);
        Assert.AreEqual(id,result.Id);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidEmailException))]
    [DataRow("pedro.tarqui@uab")]
    [DataRow("pedro.tarquiuab.edu.bo")]
    [DataRow("pedro.tarquiuabedubo")]
    public void ValidateEmailExceptionTest(string email)
    {
        Guid id = Guid.NewGuid();
        string name = "Pedro";
        string lastname = "Tarqui";
        string phoneNumber = "74903140";
        DateTime birthdate = new DateTime(2001, 02, 18);

        PersonModel result = new PersonModel(id, name, lastname, email, phoneNumber, birthdate);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidPhoneNumberException))]
    [DataRow("74903181~")]
    [DataRow("+74903140/")]
    [DataRow("+ 59174903.140")]
    [DataRow("+ 591 74903-140")]
    [DataRow("+ 591 74903140 = 3123123")]
    public void ValidatePhoneNumberExceptionTest(string phoneNumber)
    {
        Guid id = Guid.NewGuid();
        string name = "Pedro";
        string lastname = "Tarqui";
        string email = "pedro.tarqui@uab.edu.bo";
        DateTime birthdate = new DateTime(2001, 02, 18);

        PersonModel result = new PersonModel(id, name, lastname, email, phoneNumber, birthdate);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidBirthDateException))]
    public void ValidateBirthdateExceptionTest()
    {
        Guid id = Guid.NewGuid();
        string name = "Pedro";
        string lastname = "Tarqui";
        string email = "pedro.tarqui@uab.edu.bo";
        string phoneNumber = "74903140";
        DateTime birthdate = new DateTime(2012, 01, 01);

        PersonModel result = new PersonModel(id, name, lastname, email, phoneNumber, birthdate);
    }
    
}
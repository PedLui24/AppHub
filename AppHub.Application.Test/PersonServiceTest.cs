using AppHub.Application.Services;
using AppHub.Application.Test.Common;
using AppHub.Domain.Models;

namespace AppHub.Application.Test;

[TestClass]
public class PersonServiceTest: TestBase
{
    [TestMethod]
    public async Task CreateTest()
    {
        Guid id = Guid.NewGuid();
        string name = "Pedro";
        string lastname = "Tarqui";
        string email = "pedro.tarqui@uab.edu.bo";
        string phoneNumber = "74903140";
        DateTime birthdate = new DateTime(2001, 02, 18);
        PersonModel personModel = new PersonModel(
            id, 
            name, 
            lastname, 
            email, 
            phoneNumber, 
            birthdate
        );
        var personService = base.Resolve<PersonService>();
        //var personService = base.Resolve<PersonService>();
        var result = await personService.Create(personModel);
        //var result = await personService.Create(personModel);
        
        Assert.IsNotNull(result);
    }
}
using System.Data.Entity;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.DataAccess;
using ODL.DataAccess.Repositories;

[TestFixture]
public class AdressServiceTest
{
    protected ODLDbContext context;
    protected DbContextTransaction transaction;

    [SetUp]
    public void TransactionTestStart()
    {
        Database.SetInitializer<ODLDbContext>(null);
        context = new ODLDbContext();
        transaction = context.Database.BeginTransaction();
    }


    [Test]
    public void SparaPersonAdress_WhenNew_ThenSaved()
    {

        var personRepositoryMock = new Mock<IPersonRepository>().Object;
        var adressRepositoryMock = new Mock<IAdressRepository>().Object;
        var loggerMock = new Mock<ILogger<AdressService>>().Object;

        //var service = new AdressService(new PersonRepository(context), adressRepositoryMock, loggerMock);
        //var person = new PersonInputDTO
        //{
        //    SystemId = "435345",
        //    Fornamn = "Anna",
        //    Efternamn = "Nilsson",
        //    Personnummer = "198002254543",
        //    SkapadAv = "MEH",
        //    SkapadDatum = "2005-01-02",
        //    UppdateradAv = "MEH",
        //    UppdateradDatum = "2017-02-01"
        //};
        //service.SparaPerson(person);

        //var sparadPersonAdress = service.g.GetPersonByPersonnummer("198002254543");
        //Assert.That(sparadPerson, Is.Not.Null);
    }

    [TearDown]
    public void TransactionTestEnd()
    {
        transaction.Rollback();
        transaction.Dispose();
        context.Dispose();
    }
}

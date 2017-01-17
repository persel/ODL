
using System.Data.Entity;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.DataAccess;
using ODL.DataAccess.Repositories;

[TestFixture]
public class PersonServiceTests
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
    public void SparaPerson_Ok()
    {
        
        var organisationRepositoryMock = new Mock<IOrganisationRepository>().Object;
        var avtalRepositoryMock = new Mock<IAvtalRepository>().Object;
        var loggerMock = new Mock<ILogger<PersonService>>().Object;

        var service = new PersonService(new PersonRepository(context), organisationRepositoryMock, avtalRepositoryMock, loggerMock);
        var person = new PersonInputDTO
        {
            SystemId = "435345",
            Fornamn = "Anna",
            Efternamn = "Nilsson",
            Personnummer = "198002254543",
            SkapadAv = "MEH",
            SkapadDatum = "2005-01-02",
            UppdateradAv = "MEH",
            UppdateradDatum = "2017-02-01"
        };
        service.SparaPerson(person);

        var sparadPerson = service.GetPersonByPersonnummer("198002254543");
        Assert.That(sparadPerson, Is.Not.Null);
    }

    [TearDown]
    public void TransactionTestEnd()
    {
        transaction.Rollback();
        transaction.Dispose();
        context.Dispose();
    }


}

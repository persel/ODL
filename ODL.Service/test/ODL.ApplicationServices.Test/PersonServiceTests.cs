
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.DataAccess;
using ODL.DataAccess.Repositories;
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;


[TestFixture]
public class PersonServiceTests
{
    protected ODLDbContext context;
    protected DbContextTransaction transaction;

    //[SetUp]
    //public void TransactionTestStart()
    //{
    //    Database.SetInitializer<ODLDbContext>(null);
    //    context = new ODLDbContext();
    //    transaction = context.Database.BeginTransaction();
    //}

    [Test]
    public void SparaPerson_WhenNew_ThenSaved()
    {
        
        var personRepositoryMock = new Mock<IPersonRepository>();

        //Setup 
        var personlist = new List<Person>();
        personRepositoryMock.Setup(m => m.Add((It.IsAny<Person>()))).Callback<Person>(personlist.Add);
        personRepositoryMock.Setup(m => m.GetByPersonnummer(It.IsAny<string>())).Returns(new Person() );

        var organisationRepositoryMock = new Mock<IOrganisationRepository>().Object;
        var avtalRepositoryMock = new Mock<IAvtalRepository>().Object;
        var loggerMock = new Mock<ILogger<PersonService>>().Object;

        var service = new PersonService( personRepositoryMock.Object, organisationRepositoryMock, avtalRepositoryMock, loggerMock);

        var person = new PersonInputDTO
        {
            SystemId = "435345",
            Fornamn = "Anna",
            Efternamn = "Nilsson",
            Personnummer = "198002254543",
            SkapadAv = "MEH",
            SkapadDatum = "2005-01-02 12:00",
            UppdateradAv = "MEH",
            UppdateradDatum = "2017-02-01 12:00"
        };
        service.SparaPerson(person);
        var sparadPerson = service.GetPersonByPersonnummer("198002254543");

      
        Assert.That(sparadPerson, Is.Not.Null);
    }


    //[Test]
    //public void SparaPerson_WhenNew_ThenSaved()
    //{

    //    var organisationRepositoryMock = new Mock<IOrganisationRepository>().Object;
    //    var avtalRepositoryMock = new Mock<IAvtalRepository>().Object;
    //    var loggerMock = new Mock<ILogger<PersonService>>().Object;

    //    var service = new PersonService(new PersonRepository(context), organisationRepositoryMock, avtalRepositoryMock, loggerMock);
    //    var person = new PersonInputDTO
    //    {
    //        SystemId = "435345",
    //        Fornamn = "Anna",
    //        Efternamn = "Nilsson",
    //        Personnummer = "198002254543",
    //        SkapadAv = "MEH",
    //        SkapadDatum = "2005-01-02 12:00",
    //        UppdateradAv = "MEH",
    //        UppdateradDatum = "2017-02-01 12:00"
    //    };
    //    service.SparaPerson(person);

    //    var sparadPerson = service.GetPersonByPersonnummer("198002254543");
    //    Assert.That(sparadPerson, Is.Not.Null);
    //}

    //[TearDown]
    //public void TransactionTestEnd()
    //{
    //    transaction.Rollback();
    //    transaction.Dispose();
    //    context.Dispose();
    //}


}

public class MockStore
{

    public List<Person> Person { get; set; }
    public List<Avtal> Avtal { get; set; }

    public List<Organisation> Organisation { get; set; }


    public MockStore()
    {
        this.Person = new List<Person>();

        this.Avtal = new List<Avtal>();

        this.Organisation = new List<Organisation>();

    }

}

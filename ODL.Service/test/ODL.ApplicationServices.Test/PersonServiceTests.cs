
using System.Data.Entity;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.DataAccess;
using ODL.DataAccess.Repositories;

namespace ODL.ApplicationServices.Test
{
    [TestFixture]
    public class PersonServiceTests
    {
        protected ODLDbContext context;
        protected DbContextTransaction transaction;

        [SetUp]
        public void TransactionTestStart()
        {
            Database.SetInitializer<ODLDbContext>(null);

            var testConnection =
                "Server = ds1ptjsql03; " +
                "Database = ODL_CI_Test_Only; " +
                "Trusted_Connection = False; " +
                "MultipleActiveResultSets = true; " +
                "Integrated Security = false; " +
                "User ID = svcUser;" +
                " Password = abcd1234";

            context = new ODLDbContext(testConnection);
            transaction = context.Database.BeginTransaction();
        }


        [Test]
        [Category("LongRunning")]
        public void SparaPerson_WhenNew_ThenSaved()
        {

            var organisationRepositoryMock = new Mock<IOrganisationRepository>().Object;
            var avtalRepositoryMock = new Mock<IAvtalRepository>().Object;
            var dbContextMock = new Mock<IContext>().Object;
            var loggerMock = new Mock<ILogger<PersonService>>().Object;

            var service = new PersonService(new PersonRepository(context), organisationRepositoryMock, avtalRepositoryMock, dbContextMock, loggerMock);
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

        [TearDown]
        public void TransactionTestEnd()
        {
            transaction.Rollback();
            transaction.Dispose();
            context.Dispose();
        }

    }
}


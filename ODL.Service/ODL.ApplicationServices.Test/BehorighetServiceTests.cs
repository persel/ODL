
using System.Data.Entity;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel.Behorighet;
using ODL.DataAccess;
using ODL.DataAccess.Repositories.Behorighet;

[TestFixture]
public class BehorighetServiceTests
{
    private ODLDbContext context;
    private DbContextTransaction transaction;
    private BehorighetService behorighetService;

    [OneTimeSetUp]
    public void TransactionTestStart()
    {
        Database.SetInitializer<ODLDbContext>(null);
        context = new ODLDbContext();
        transaction = context.Database.BeginTransaction();
    }


    [Test]
    public void SparaPersonal_Ok()
    {
        var personalRepository = new PersonalRepository(context);
        var anvandareRepositoryMock = new Mock<IAnvandareRepository>().Object;
        var systemRepositoryMock = new Mock<ISystemRepository>().Object;
        var verksamhetsrollRepositoryMock = new Mock<IVerksamhetsrollRepository>().Object;
        var systemattributRepositoryMock = new Mock<ISystemattributRepository>().Object;
        var verksamhetsdimensionRepositoryMock = new Mock<IVerksamhetsdimensionRepository>().Object;
        var loggerMock = new Mock<ILogger<BehorighetService>>().Object;

        var service = new BehorighetService(personalRepository, anvandareRepositoryMock, systemRepositoryMock, verksamhetsrollRepositoryMock, systemattributRepositoryMock, verksamhetsdimensionRepositoryMock, loggerMock);
        var personal = new PersonalDTO
        {
            Fornamn = "Anna",
            Efternamn = "Nilsson",
            Personnummer = "198002254543"

        };
        service.SparaPersonal(personal);

        var sparadPerson = personalRepository.GetPersonalByPersonnummer(personal.Personnummer);
        Assert.That(sparadPerson, Is.Not.Null);
    }

    [OneTimeTearDown]
    public void TransactionTestEnd()
    {
        transaction.Rollback();
        transaction.Dispose();
        context.Dispose();
    }
}

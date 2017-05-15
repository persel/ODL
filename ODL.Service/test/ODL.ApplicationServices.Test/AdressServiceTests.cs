//using System.Data.Entity;
//using Microsoft.Extensions.Logging;
//using Moq;
//using NUnit.Framework;
//using ODL.ApplicationServices;
//using ODL.ApplicationServices.DTOModel;
//using ODL.ApplicationServices.DTOModel.Load;
//using ODL.DataAccess;
//using ODL.DataAccess.Repositories;

//[TestFixture]
//public class AdressServiceTest
//{
//    protected ODLDbContext context;
//    protected DbContextTransaction transaction;

//    [SetUp]
//    public void TransactionTestStart()
//    {
//        Database.SetInitializer<ODLDbContext>(null);
//        context = new ODLDbContext();
//        transaction = context.Database.BeginTransaction();
//    }


//    [Test]
//    public void SparaPersonAdress_WhenNew_ThenSaved()
//    {

//        var personRepositoryMock = new Mock<IPersonRepository>().Object;
//        var adressRepositoryMock = new Mock<IAdressRepository>().Object;
//        var loggerMock = new Mock<ILogger<AdressService>>().Object;

//        var service = new AdressService(new AdressRepository(context),  new PersonRepository(context), new OrganisationRepository(context), new AdressVariantRepository(context), loggerMock);
//        var personGatauAdress = new PersonAdressInputDTO
//        {
//            Personnummer = "197012123456",
//            AdressVariant = "LeveransAdress",
//            GatuadressInput = new GatuadressInputDTO
//            {
//                AdressRad1 = "Gatan 2",
//                AdressRad2 = "",
//                AdressRad3 = "",
//                AdressRad4 = "",
//                AdressRad5 = "",
//                Postnummer = 74141,
//                Stad = "Knivsta",
//                Land = "USA"
//            },
//            EpostInput = null,
//            TelefonInput = null,
//            SystemId = null,
//            UppdateradDatum = "2017-01-20 12:00",
//            UppdateradAv = "MAH",
//            SkapadDatum = "2017-01-20 12:00",
//            SkapadAv = "MAH"
//        };
//        service.SparaPersonAdress(personGatauAdress);

//        var sparadPersonAdress = service.GetAdresserPerPersonnummer("197012123456");
//        Assert.That(sparadPersonAdress, Is.Not.Null);
//    }

//    [TearDown]
//    public void TransactionTestEnd()
//    {
//        transaction.Rollback();
//        transaction.Dispose();
//        context.Dispose();
//    }
//}

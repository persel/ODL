using System;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.DataAccess.Repositories;
using ODL.DomainModel;
using ODL.DomainModel.Person;

namespace ODL.ApplicationServices.Test.Mock
{
    [TestFixture]
    public class PersonServiceTests
    {
        private PersonInputDTO person;

        private Mock<IPersonRepository> personRepositoryMock;
        private Mock<IOrganisationRepository> organisationRepositoryMock;
        private Mock<IAvtalRepository> avtalRepositoryMock;
        private Mock<ILogger<PersonService>> loggerMock;
        private PersonService service;

        [SetUp]
        public void Initiera()
        {
            person = new PersonInputDTO
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

            personRepositoryMock = new Mock<IPersonRepository>();
            organisationRepositoryMock = new Mock<IOrganisationRepository>();
            avtalRepositoryMock = new Mock<IAvtalRepository>();
            loggerMock = new Mock<ILogger<PersonService>>();
            service = new PersonService(personRepositoryMock.Object, organisationRepositoryMock.Object, avtalRepositoryMock.Object, loggerMock.Object);
    }


        [Test]
        public void SparaPerson_WhenNew_ThenSaved()
        {
            service.SparaPerson(person);
            personRepositoryMock.Verify(m => m.Add(It.IsAny<Person>()));
        }


        [Test]
        public void SparaPerson_WhenExisting_ThenUpdated()
        {
            personRepositoryMock.Setup(m => m.GetByPersonnummer(It.IsAny<string>())).Returns(new Person {Id = 1});
            
            service.SparaPerson(person);
            personRepositoryMock.Verify(m => m.Update());
        }

        [Test]
        public void SparaPerson_MissingFirstName_ValidationError()
        {
            person.Fornamn = null;
            
            Expect<BusinessLogicException>(() => service.SparaPerson(person),
                $"Valideringsfel inträffade vid validering av Person med Id: {person.Personnummer}.");
        }

        [Test]
        public void SparaPerson_ValidationError_MissingPersNr()
        {
            person.Personnummer = null;
            
            Expect<BusinessLogicException>(() => service.SparaPerson(person),
                $"Valideringsfel inträffade vid validering av Person med Id: {person.Personnummer}.");
        }

        [Test]
        public void SparaAvtal_MissingKstnr_Fail()
        {
            //var avtal = new AvtalInputDTO()
            //{
            //    Kostnadsstallen = new List<OrganisationAvtalInputDTO>() { new OrganisationAvtalInputDTO(){KostnadsstalleNr = 12345} },
            //    AnstalldPersonnummer = "198002254543",
            //    SkapadAv = "MEH",
            //    SkapadDatum = "2005-01-02 12:00",
            //    UppdateradAv = "MEH",
            //    UppdateradDatum = "2017-02-01 12:00"
            //};

            //// Verifiera service.SparaAvtal
            
        }


        /// <summary>
        ///     En liten hjälpmetod för att hjälpa till att verifiera fel och felmeddelanden.
        /// </summary>
        public static void Expect<TException>(TestDelegate action, string message = null) where TException : Exception
        {
            var exception = Assert.Throws<TException>(action);
            
            if (message != null)
                Assert.That(exception.Message, Is.EqualTo(message));
        }
    }
}



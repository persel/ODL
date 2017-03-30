using System;
using System.Collections.Generic;
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
        [Test]
        [Category("ShortRunning")]
        public void SparaPerson_WhenNew_ThenSaved()
        {
            var personRepositoryMock = new Mock<IPersonRepository>();

            //Setup 
            var personlist = new List<Person>();
            personRepositoryMock.Setup(m => m.Add(It.IsAny<Person>())).Callback<Person>(personlist.Add);

            var person1 = new Person {Fornamn = "Pelle", Personnummer = "199902254543"};

            personRepositoryMock.Setup(m => m.GetByPersonnummer(It.IsAny<string>())).Returns(person1);

            var organisationRepositoryMock = new Mock<IOrganisationRepository>().Object;
            var avtalRepositoryMock = new Mock<IAvtalRepository>().Object;
            var loggerMock = new Mock<ILogger<PersonService>>().Object;

            var service = new PersonService(personRepositoryMock.Object, organisationRepositoryMock, avtalRepositoryMock,
                loggerMock);

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

            Assert.That(sparadPerson.Personnummer, Is.EqualTo(sparadPerson.Personnummer));
        }

        [Test]
        [Category("ShortRunning")]
        public void SparaPerson_ValidationError_MissingFirstName()
        {
            var personRepositoryMock = new Mock<IPersonRepository>();

            //Setup 
            var personlist = new List<Person>();
            personRepositoryMock.Setup(m => m.Add(It.IsAny<Person>())).Callback<Person>(personlist.Add);
            personRepositoryMock.Setup(m => m.GetByPersonnummer(It.IsAny<string>())).Returns(new Person());

            var organisationRepositoryMock = new Mock<IOrganisationRepository>().Object;
            var avtalRepositoryMock = new Mock<IAvtalRepository>().Object;
            var loggerMock = new Mock<ILogger<PersonService>>().Object;

            var service = new PersonService(personRepositoryMock.Object, organisationRepositoryMock, avtalRepositoryMock,
                loggerMock);

            var person = new PersonInputDTO
            {
                SystemId = "435345",
                //Fornamn = "Anna",
                Efternamn = "Nilsson",
                Personnummer = "198002254543",
                SkapadAv = "MEH",
                SkapadDatum = "2005-01-02 12:00",
                UppdateradAv = "MEH",
                UppdateradDatum = "2017-02-01 12:00"
            };


            Expect<BusinessLogicException>(() => service.SparaPerson(person),
                $"Valideringsfel inträffade vid validering av Person med Id: {person.Personnummer}.");
        }

        [Test]
        [Category("ShortRunning")]
        public void SparaPerson_ValidationError_MissingPersNr()
        {
            var personRepositoryMock = new Mock<IPersonRepository>();

            //Setup 
            var personlist = new List<Person>();
            personRepositoryMock.Setup(m => m.Add(It.IsAny<Person>())).Callback<Person>(personlist.Add);
            personRepositoryMock.Setup(m => m.GetByPersonnummer(It.IsAny<string>())).Returns(new Person());

            var organisationRepositoryMock = new Mock<IOrganisationRepository>().Object;
            var avtalRepositoryMock = new Mock<IAvtalRepository>().Object;
            var loggerMock = new Mock<ILogger<PersonService>>().Object;

            var service = new PersonService(personRepositoryMock.Object, organisationRepositoryMock, avtalRepositoryMock,
                loggerMock);

            var person = new PersonInputDTO
            {
                SystemId = "435345",
                Fornamn = "Anna",
                Efternamn = "Nilsson",
                //Personnummer = "0",
                SkapadAv = "MEH",
                SkapadDatum = "2005-01-02 12:00",
                UppdateradAv = "MEH",
                UppdateradDatum = "2017-02-01 12:00"
            };


            Expect<BusinessLogicException>(() => service.SparaPerson(person),
                $"Valideringsfel inträffade vid validering av Person med Id: {person.Personnummer}.");
        }

        [Test]
        [Category("ShortRunning")]
        public void SparaAvtal_FailMissingKstnr()
        {
            var personRepositoryMock = new Mock<IPersonRepository>();

            //Setup 
            var personlist = new List<Person>();
            personRepositoryMock.Setup(m => m.Add(It.IsAny<Person>())).Callback<Person>(personlist.Add);
            personRepositoryMock.Setup(m => m.GetByPersonnummer(It.IsAny<string>())).Returns(new Person());

            var organisationRepositoryMock = new Mock<IOrganisationRepository>().Object;

            var avtallist = new List<Avtal>();
            var avtallist2 = new List<OrganisationAvtal>();
            var avtalRepositoryMock = new Mock<IAvtalRepository>();
            avtalRepositoryMock.Setup(m => m.Add(It.IsAny<Avtal>())).Callback<Avtal>(avtallist.Add);
            //avtalRepositoryMock.Setup(m => m.Add(It.IsAny<Avtal>())).Callback<OrganisationAvtal>(avtallist2.Add);

            var loggerMock = new Mock<ILogger<PersonService>>().Object;

            var service = new PersonService(personRepositoryMock.Object, organisationRepositoryMock, avtalRepositoryMock.Object,
                loggerMock);

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

            var avtal = new AvtalInputDTO()
            {
                Kostnadsstallen = new List<OrganisationAvtalInputDTO>() { new OrganisationAvtalInputDTO(){KostnadsstalleNr = 12345} },
                AnstalldPersonnummer = "198002254543",
                SkapadAv = "MEH",
                SkapadDatum = "2005-01-02 12:00",
                UppdateradAv = "MEH",
                UppdateradDatum = "2017-02-01 12:00"



            };
            

            Expect<ArgumentException>(() => service.SparaAvtal(avtal),
                $"Avtalet kunde inte sparas - angiven resultatenhet med KstNr '12345' saknas i ODL.");

           
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



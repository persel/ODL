using ODL.DomainModel.Adress;
using ODL.DomainModel.Common;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ODL.DataAccess.ODLDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ODL.DataAccess.ODLDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.AdressVariant.AddOrUpdate(
              new AdressVariant { Id = 1 , Namn = "Folkbokföringsadress"},
              new AdressVariant { Id = 2, Namn = "Adress Arbete" },
              new AdressVariant { Id = 3, Namn = "LeveransAdress" },
              new AdressVariant { Id = 4, Namn = "FaktureringsAdress" },
              new AdressVariant { Id = 5, Namn = "Adressens Adress" },
              new AdressVariant { Id = 6, Namn = "Tomte Adress" },
              new AdressVariant { Id = 7, Namn = "MailAdress Arbete" },
              new AdressVariant { Id = 8, Namn = "Mailadress Privat" },
              new AdressVariant { Id = 9, Namn = "Mobil Arbete" },
              new AdressVariant { Id = 10, Namn = "Mobil Privat" },
              new AdressVariant { Id = 11, Namn = "Telefon Arbete" },
              new AdressVariant { Id = 12, Namn = "Telefon Privat" },
              new AdressVariant { Id = 13, Namn = "Facebook Privat" },
              new AdressVariant { Id = 14, Namn = "Facebook Arbete" }
            );
            var metadata = new Metadata() {SkapadAv = "DBO", SkapadDatum = DateTime.Now, UppdateradAv = "DBO", UppdateradDatum = DateTime.Now };
            context.Person.AddOrUpdate(
                new Person {KallsystemId = "93574395", Fornamn = "Kalle", Mellannamn = "Ove", Efternamn = "Nilsson", Personnummer = "197012123456", Metadata = metadata},
                new Person { KallsystemId = "39487983", Fornamn = "Marie", Mellannamn = "Eva", Efternamn = "Persson", Personnummer = "196212303456", Metadata = metadata },
                new Person { KallsystemId = "48795842", Fornamn = "Anders", Mellannamn = "Ola", Efternamn = "Svensson", Personnummer = "197505223456", Metadata = metadata },
                new Person { KallsystemId = "93285742", Fornamn = "Per", Mellannamn = "Sven", Efternamn = "Andersson", Personnummer = "198512123456", Metadata = metadata }
            );

            //context.Adress.AddOrUpdate(
            //    new Adress { }    
                
            //);
        }
    }
}

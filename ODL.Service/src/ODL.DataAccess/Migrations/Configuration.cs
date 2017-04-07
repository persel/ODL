using System;
using System.Data.Entity.Migrations;
using System.Configuration;
using System.Data.SqlClient;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Common;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Migrations
{
    
    internal sealed class Configuration : DbMigrationsConfiguration<ODLDbContext>
    {
        private bool insertTestdata;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ODLDbContext context)
        {
            insertTestdata = bool.TryParse(ConfigurationManager.AppSettings["insert-testdata"], out insertTestdata);

            foreach (var enumValue in Enum.GetValues(typeof(AdressTyp)))
                context.Database.ExecuteSqlCommand("INSERT INTO Adress.AdressTyp VALUES(@Id, @Namn)", new SqlParameter("Id", (int)(AdressTyp)enumValue), new SqlParameter("Namn", ((AdressTyp)enumValue).Visningstext()));
            
            context.AdressVariant.AddOrUpdate(
                new AdressVariant("Folkbokföringsadress", AdressTyp.GatuAdress),
                new AdressVariant ("Adress arbete", AdressTyp.GatuAdress),
                new AdressVariant("Leveransadress", AdressTyp.GatuAdress),
                new AdressVariant("Faktureringsadress", AdressTyp.GatuAdress),
                new AdressVariant("Mailadress arbete", AdressTyp.MailAdress),
                new AdressVariant("Mailadress privat", AdressTyp.MailAdress),
                new AdressVariant("Mobil arbete", AdressTyp.Telefon),
                new AdressVariant("Mobil privat", AdressTyp.Telefon),
                new AdressVariant("Telefon arbete", AdressTyp.Telefon),
                new AdressVariant("Telefon privat", AdressTyp.Telefon),
                new AdressVariant("Facebook arbete", AdressTyp.Facebook));
            

            if (insertTestdata)
            {
                var metadata = new Metadata {SkapadAv = "DBO", SkapadDatum = DateTime.Now, UppdateradAv = "DBO", UppdateradDatum = DateTime.Now };
                context.Person.AddOrUpdate(
                    new Person {KallsystemId = "93574395", Fornamn = "Kalle", Mellannamn = "Ove", Efternamn = "Nilsson", Personnummer = "197012123456", Metadata = metadata},
                    new Person { KallsystemId = "39487983", Fornamn = "Marie", Mellannamn = "Eva", Efternamn = "Persson", Personnummer = "196212303456", Metadata = metadata },
                    new Person { KallsystemId = "48795842", Fornamn = "Anders", Mellannamn = "Ola", Efternamn = "Svensson", Personnummer = "197505223456", Metadata = metadata },
                    new Person { KallsystemId = "93285742", Fornamn = "Per", Mellannamn = "Sven", Efternamn = "Andersson", Personnummer = "198512123456", Metadata = metadata }
                );
            }
        }
    }
}

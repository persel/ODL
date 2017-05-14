using System;
using System.Data.Entity.Migrations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Common;
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Migrations
{
    
    internal sealed class Configuration : DbMigrationsConfiguration<ODLDbContext>
    {
        private bool insertTestdata;
        private static readonly Metadata Metadata = new Metadata { SkapadAv = "DBO", SkapadDatum = DateTime.Now, UppdateradAv = "DBO", UppdateradDatum = DateTime.Now };

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ODLDbContext context)
        {
            bool.TryParse(ConfigurationManager.AppSettings["insert-testdata"], out insertTestdata);
            
            if (insertTestdata)
            {
                Person person1 = null;
                if (context.Person.ToList().Count == 0)
                {     
                    person1 = SparaNyPerson(new Person { KallsystemId = "93574395", Fornamn = "Kalle", Mellannamn = "Ove", Efternamn = "Nilsson", Personnummer = "197012123456", Metadata = Metadata }, context);
                    SparaNyPerson(new Person { KallsystemId = "39487983", Fornamn = "Marie", Mellannamn = "Eva", Efternamn = "Persson", Personnummer = "196212303456", Metadata = Metadata }, context);
                    SparaNyPerson(new Person { KallsystemId = "48795842", Fornamn = "Anders", Mellannamn = "Ola", Efternamn = "Svensson", Personnummer = "197505223456", Metadata = Metadata }, context);
                    SparaNyPerson(new Person { KallsystemId = "93285742", Fornamn = "Per", Mellannamn = "Sven", Efternamn = "Andersson", Personnummer = "198512123456", Metadata = Metadata }, context);
                    SparaNyPerson(new Person { KallsystemId = "93285742", Fornamn = "Stina", Mellannamn = "Lisa", Efternamn = "Einarsson", Personnummer = "198512123456", Metadata = Metadata }, context);
                    
                    SparaAdresser(context);
                }
                
                if (context.Organisation.ToList().Count == 0)
                {
                    var organisation1 = SparaNyOrganisation("12345", "H", "1234567", "Södra ortopedmottagningen", context);
                    SparaNyOrganisation("23456", "H", "2345678", "Norra ortopedmottagningen", context);
                    SparaNyOrganisation("34567", "G", "3456789", "Tandläkarna i Väst, Gemensamma", context);
                    SparaNyOrganisation("45678", "H", "4567890", "Järvsö vård och ved", context);

                    SparaNyttAnstalldAvtal(new Avtal
                    {
                        KallsystemId = "334567349534",
                        Avtalskod = "K01",
                        Avtalstext = "Anställningsavtal X",
                        ArbetstidVecka = 24,
                        Befkod = 1,
                        BefText = "Tandläkare",
                        Aktiv = true,
                        Ansvarig = true,
                        Chef = true,
                        GrundArbtidVecka = 40,
                        Lon = 38400,
                        TimLon = 400,
                        Anstallningsdatum = DateTime.Now,
                        Metadata = Metadata
                    }, person1, organisation1, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    {
                        KallsystemId = "349534334567",
                        Avtalskod = "K02",
                        Avtalstext = "Anställningsavtal Y",
                        ArbetstidVecka = 16,
                        Befkod = 1,
                        BefText = "Odontologkonsult",
                        Aktiv = true,
                        Ansvarig = false,
                        Chef = true,
                        GrundArbtidVecka = 40,
                        Lon = 25600,
                        TimLon = 400,
                        Anstallningsdatum = DateTime.Now,
                        Metadata = Metadata
                    }, person1, organisation1, true, 100m, context);
                    
                }
            }
        }

        private static void SparaAdressvarianter(ODLDbContext context)
        {
            //Adresstyp
            foreach (var enumValue in Enum.GetValues(typeof(Adresstyp)))
                context.Database.ExecuteSqlCommand("INSERT INTO Adress.Adresstyp VALUES(@Id, @Namn)", new SqlParameter("Id", (int)(Adresstyp)enumValue), new SqlParameter("Namn", ((Adresstyp)enumValue).Visningstext()));

            //Adressvariant
            foreach (var enumValue in Enum.GetValues(typeof(Adressvariant)))
                context.Database.ExecuteSqlCommand("INSERT INTO Adress.Adressvariant VALUES(@Id, @Namn, @AdresstypFKId)", 
                    new SqlParameter("Id", (int)(Adressvariant)enumValue), 
                    new SqlParameter("Namn", ((Adressvariant)enumValue).Visningstext()), 
                    new SqlParameter("AdresstypFKId", (int)((Adressvariant)enumValue).Adresstyp()));

            context.SaveChanges();

        }

        private Person SparaNyPerson(Person person, ODLDbContext context)
        {
            context.Person.AddOrUpdate(person);
            return person;
        }

        private void SparaAdresser(ODLDbContext context)
        {
           
            var person1 = context.Person.ToList().Single(p => p.Fornamn == "Kalle" && p.Mellannamn == "Ove");
            var adress1Hem = Adress.SkapaNyGatuadress("Hemmavägen 11", "84019", "Färila", "Sverige", Adressvariant.Folkbokforingsadress, Metadata, person1);
            var adress1Arbete = Adress.SkapaNyGatuadress("Arbetarvägen 23", "82240", "Järvsö", "Sverige", Adressvariant.AdressArbete, Metadata, person1);
            var adress1MailPrivat = Adress.SkapaNyEpostAdress("kalle.ove@gmail.com", Adressvariant.EpostAdressPrivat, Metadata, person1);
            var adress1MailArbete = Adress.SkapaNyEpostAdress("jobb.jarvsobacken@ptj.se", Adressvariant.EpostAdressArbete, Metadata, person1);
            var adress1TelArbete = Adress.SkapaNyTelefonAdress("070771567", Adressvariant.TelefonArbete, Metadata, person1);
            var adress1TelPrivat = Adress.SkapaNyTelefonAdress("065161243", Adressvariant.TelefonPrivat, Metadata, person1);
            
            var person2 = context.Person.ToList().Find(p => p.Personnummer == "196212303456");
            var adress2Hem = Adress.SkapaNyGatuadress("Hemvägen 3", "82240", "Järvsö", "Sverige", Adressvariant.Folkbokforingsadress, Metadata, person2);

            context.Adress.AddOrUpdate(
                adress1Hem,
                adress1Arbete,
                adress1MailPrivat,
                adress1MailArbete,
                adress1TelArbete,
                adress1TelPrivat,
                adress2Hem
            );
        }

        private Organisation SparaNyOrganisation(string kstNr, string typ, string organisationsId, string namn, ODLDbContext context)
        {
           
            var organisation = Organisation.SkapaNyResultatenhet(kstNr, typ, organisationsId, namn, Metadata);

            context.Organisation.AddOrUpdate(organisation);

            return organisation;
        }

        private void SparaNyttAnstalldAvtal(Avtal avtal, Person person, Organisation organisation, bool huvudkostnadsstalle, decimal? procentuellFordelning, ODLDbContext context)
        {
            avtal.KopplaTillKonsult(person);
            avtal.LaggTillOrganisation(organisation, huvudkostnadsstalle, procentuellFordelning);
            context.Avtal.AddOrUpdate(avtal);
        }
        private void SparaNyttKonsultAvtal(Avtal avtal, Person person, Organisation organisation, bool huvudkostnadsstalle, decimal? procentuellFordelning, ODLDbContext context)
        {
            avtal.KopplaTillKonsult(person);
            avtal.LaggTillOrganisation(organisation, huvudkostnadsstalle, procentuellFordelning);
            context.Avtal.AddOrUpdate(avtal);
        }
    }
}

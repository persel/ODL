using System;
using System.Data.Entity.Migrations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using ODL.DomainModel;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Common;
using ODL.DomainModel.Organisation;
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

            if (context.AdressVariant.ToList().Count == 0)
            {
               AddAdressTypVarianter(ref context);
            }

            
            if (insertTestdata)
            {
                if (context.Person.ToList().Count == 0)
                {     
                    AddPerson(ref context);
                    context.SaveChanges();

                    AddAdress(ref context);
                    
                }


                if (context.Organisation.ToList().Count == 0)
                {
                    AddOrganisation(ref context);
                    context.SaveChanges();
                    AddAvtal(ref context);
                }
                
            }
        }

        private static void AddAdressTypVarianter(ref ODLDbContext context)
        {
            //AdressTyp
            foreach (var enumValue in Enum.GetValues(typeof(AdressTyp)))
                context.Database.ExecuteSqlCommand("INSERT INTO Adress.AdressTyp VALUES(@Id, @Namn)", new SqlParameter("Id", (int)(AdressTyp)enumValue), new SqlParameter("Namn", ((AdressTyp)enumValue).Visningstext()));

            //AdressVariant
            context.AdressVariant.AddOrUpdate(
                new AdressVariant("Folkbokföringsadress", AdressTyp.Gatuadress),
                new AdressVariant("Adress arbete", AdressTyp.Gatuadress),
                new AdressVariant("Leveransadress", AdressTyp.Gatuadress),
                new AdressVariant("Faktureringsadress", AdressTyp.Gatuadress),
                new AdressVariant("Mailadress arbete", AdressTyp.MailAdress),
                new AdressVariant("Mailadress privat", AdressTyp.MailAdress),
                new AdressVariant("Mobil arbete", AdressTyp.Telefon),
                new AdressVariant("Mobil privat", AdressTyp.Telefon),
                new AdressVariant("Telefon arbete", AdressTyp.Telefon),
                new AdressVariant("Telefon privat", AdressTyp.Telefon),
                new AdressVariant("Facebook arbete", AdressTyp.Facebook));

            context.SaveChanges();

        }

        private static void AddPerson( ref ODLDbContext context)
        {
            var metadata = new Metadata { SkapadAv = "DBO", SkapadDatum = DateTime.Now, UppdateradAv = "DBO", UppdateradDatum = DateTime.Now };
            context.Person.AddOrUpdate(
                new Person
                {
                    KallsystemId = "93574395",
                    Fornamn = "Kalle",
                    Mellannamn = "Ove",
                    Efternamn = "Nilsson",
                    Personnummer = "197012123456",
                    Metadata = metadata
                },
                new Person
                {
                    KallsystemId = "39487983",
                    Fornamn = "Marie",
                    Mellannamn = "Eva",
                    Efternamn = "Persson",
                    Personnummer = "196212303456",
                    Metadata = metadata
                },
                new Person { KallsystemId = "48795842", Fornamn = "Anders", Mellannamn = "Ola", Efternamn = "Svensson", Personnummer = "197505223456", Metadata = metadata },
                new Person { KallsystemId = "93285742", Fornamn = "Per", Mellannamn = "Sven", Efternamn = "Andersson", Personnummer = "198512123456", Metadata = metadata },
                new Person { KallsystemId = "93285742", Fornamn = "Stina", Mellannamn = "Lisa", Efternamn = "Einarsson", Personnummer = "198512123456", Metadata = metadata }
            );
        }

        private static void AddAdress(ref ODLDbContext context)
        {
            var metadata = new Metadata { SkapadAv = "DBO", SkapadDatum = DateTime.Now, UppdateradAv = "DBO", UppdateradDatum = DateTime.Now };

            var variantFolkbokforingsadress = context.AdressVariant.ToList().Find(a => a.Namn == "Folkbokföringsadress");
            var variantAdressArbete = context.AdressVariant.ToList().Find(a => a.Namn == "Adress arbete");
            var variantMailadressPrivat = context.AdressVariant.ToList().Find(a => a.Namn == "Mailadress privat");
            var variantMailadressArbete = context.AdressVariant.ToList().Find(a => a.Namn == "Mailadress arbete");
            var variantTelArbete = context.AdressVariant.ToList().Find(a => a.Namn == "Telefon arbete");
            var variantTelPrivate = context.AdressVariant.ToList().Find(a => a.Namn == "Telefon privat");

            var p1 = context.Person.ToList().Single(p => p.Fornamn == "Kalle" && p.Mellannamn == "Ove");

            var adress1Hem = Adress.NyGatuadress(p1);
            adress1Hem.Gatuadress.AdressRad1 = "Hemmavägen 11";
            adress1Hem.Gatuadress.Postnummer = "84019";
            adress1Hem.Gatuadress.Stad = "Färila";
            adress1Hem.Gatuadress.Land = "Sverige";
            adress1Hem.Metadata = metadata;
            adress1Hem.SetVariant(variantFolkbokforingsadress);

            var adress1Arbete = Adress.NyGatuadress(p1);
            adress1Arbete.Gatuadress.AdressRad1 = "Arbetarvägen 23";
            adress1Arbete.Gatuadress.Postnummer = "82240";
            adress1Arbete.Gatuadress.Stad = "Järvsö";
            adress1Arbete.Gatuadress.Land = "Sverige";
            adress1Arbete.Metadata = metadata;
            adress1Arbete.SetVariant(variantAdressArbete);

            var adress1MailPrivate = Adress.NyEpostAdress(p1);
            adress1MailPrivate.Mail.MailAdress = "kalle.ove@gmail.com";
            adress1MailPrivate.SetVariant(variantMailadressPrivat);
            adress1MailPrivate.Metadata = metadata;

            var adress1MailArbete = Adress.NyEpostAdress(p1);
            adress1MailArbete.Mail.MailAdress = "jobb.jarvsobacken@ptj.se";
            adress1MailArbete.SetVariant(variantMailadressArbete);
            adress1MailArbete.Metadata = metadata;

            var adress1TelArbete = Adress.NyTelefonAdress(p1);
            adress1TelArbete.Telefon.Telefonnummer = "070771567";
            adress1TelArbete.SetVariant(variantTelArbete);
            adress1TelArbete.Metadata = metadata;

            var adress1TelPrivate = Adress.NyTelefonAdress(p1);
            adress1TelPrivate.Telefon.Telefonnummer = "065161243";
            adress1TelPrivate.SetVariant(variantTelPrivate);
            adress1TelPrivate.Metadata = metadata;

            var p2 = context.Person.ToList().Find(p => p.Personnummer == "196212303456");
            var adress2 = Adress.NyGatuadress(p2);
            adress2.Gatuadress.AdressRad1 = "Hemvägen 3";
            adress2.Gatuadress.Postnummer = "82240";
            adress2.Gatuadress.Stad = "Järvsö";
            adress2.Gatuadress.Land = "Sverige";
            adress2.Metadata = metadata;
            adress2.SetVariant(variantFolkbokforingsadress);

            context.Adress.AddOrUpdate(
                adress1Hem,
                adress1Arbete,
                adress1MailPrivate,
                adress1MailArbete,
                adress1TelArbete,
                adress1TelPrivate,
                adress2
            );
            

        }

        private static void AddOrganisation(ref ODLDbContext context)
        {
            var metadata = new Metadata { SkapadAv = "DBO", SkapadDatum = DateTime.Now, UppdateradAv = "DBO", UppdateradDatum = DateTime.Now };
            var org1 = Organisation.SkapaNyResultatenhet();
            org1.Metadata = metadata;
            org1.OrganisationsId = "12345678";
            org1.Namn = "Södra ortopedmottagningen";

            var org1Resultatenhet = org1.Resultatenhet;
            org1Resultatenhet.KstNr = "12345";
            org1Resultatenhet.Typ = "H";
            org1Resultatenhet.OrganisationId = 12345678;

            var org2 = Organisation.SkapaNyResultatenhet();
            org2.Metadata = metadata;
            org2.OrganisationsId = "23456789";
            org2.Namn = "Norra ortopedmottagningen";

            var org2Resultatenhet = org2.Resultatenhet;
            org2Resultatenhet.KstNr = "12346";
            org2Resultatenhet.Typ = "H";
            org2Resultatenhet.OrganisationId = 23456789;

            var org3 = Organisation.SkapaNyResultatenhet();
            org3.Metadata = metadata;
            org3.OrganisationsId = "34567890";
            org3.Namn = "Tandläkarna i Väst, Gemensamma";

            var org3Resultatenhet = org3.Resultatenhet;
            org3Resultatenhet.KstNr = "12347";
            org3Resultatenhet.Typ = "G";
            org3Resultatenhet.OrganisationId = 34567890;

            var org4 = Organisation.SkapaNyResultatenhet();
            org4.Metadata = metadata;
            org4.OrganisationsId = "34567891";
            org4.Namn = "Järvsö vård och ved";

            var org4Resultatenhet = org4.Resultatenhet;
            org4Resultatenhet.KstNr = "32347";
            org4Resultatenhet.Typ = "H";
            org4Resultatenhet.OrganisationId = 34567890;


            context.Organisation.AddOrUpdate(org1, org2, org3, org4);

        }

        private void AddAvtal(ref ODLDbContext context)
        {
            var metadata = new Metadata { SkapadAv = "DBO", SkapadDatum = DateTime.Now, UppdateradAv = "DBO", UppdateradDatum = DateTime.Now };
            var avtal = new Avtal
            {
                KallsystemId = "334567349534",
                Avtalskod = "K01",
                Avtalstext = "Anställningsavtal X",
                ArbetstidVecka = 40,
                Befkod = 1,
                BefText = "Tandläkare",
                Aktiv = true,
                Ansvarig = true,
                Chef = true,
                GrundArbtidVecka = 40,
                Lon = 40000,
                TimLon = 400,
                Anstallningsdatum = DateTime.Now,
                Metadata = metadata,
                AnstalldAvtal = new AnstalldAvtal
                {
                    PersonId = context.Person.ToList().Single(p => p.Fornamn == "Kalle" && p.Mellannamn == "Ove").Id
                }
            };



            var orgAvtal = new OrganisationAvtal
            {
                OrganisationId = context.Organisation.ToList()
                    .Find(p => p.Namn == "Järvsö vård och ved")
                    .Id,
                Huvudkostnadsstalle = true,
                ProcentuellFordelning = 100
            };


            avtal.AddOrganisationAvtal(orgAvtal);
            context.Avtal.AddOrUpdate(avtal);

        }

    }
}

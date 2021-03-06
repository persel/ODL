using System;
using System.Data.Entity.Migrations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Avtal;
using ODL.DomainModel.Common;
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Migrations
{
    
    internal sealed class Configuration : DbMigrationsConfiguration<ODLDbContext>
    {
        private bool insertTestdata;
        private static readonly Metadata Metadata = new Metadata (DateTime.Now, "DBO", DateTime.Now, "DBO");

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ODLDbContext context)
        {
            bool.TryParse(ConfigurationManager.AppSettings["insert-testdata"], out insertTestdata);

            SparaSystemdata(context);

            if (insertTestdata)
            {
                Person person1 = null;
                Person person2 = null;
                Person person3 = null;
                Person person4 = null;
                Person person5 = null;
                Person person6 = null;
                Person person7 = null;
                Person person8 = null;
                Person person9 = null;
                Person person10 = null;
                if (context.Person.ToList().Count == 0)
                {     
                    person1 = SparaNyPerson(new Person("Kalle", "Ove", "Nilsson", "197012123456", Metadata ), context);
                    person2 = SparaNyPerson(new Person("Marie", "Eva", "Persson", "196212303456", Metadata), context);
                    person3 = SparaNyPerson(new Person("Anders", "Ola", "Svensson", "197505223456", Metadata), context);


                    person4 = SparaNyPerson(new Person ("Per", "Sven", "Andersson", "198512123456", Metadata ), context);
                    person5 = SparaNyPerson(new Person ("Stina", "Lisa", "Einarsson", "198512123456", Metadata ), context);

                    person6 = SparaNyPerson(new Person("Mustafa", "Sven", "Andersson", "195512123456", Metadata), context);
                    person7 = SparaNyPerson(new Person("Lisa", "Anna", "Einarsson", "196512123456", Metadata), context);
                    person8 = SparaNyPerson(new Person("Per", "Sven", "Andersson", "199512123456", Metadata), context);
                    person9 = SparaNyPerson(new Person("Anna", "Lisa", "Einarsson", "193512123456", Metadata), context);
                    person10 = SparaNyPerson(new Person("Ale", "Arne", "Svensson", "192512123456", Metadata), context);


                }
                
                if (context.Organisation.ToList().Count == 0)
                {
                    var organisation1 = SparaNyOrganisation("12345", Kostnadsstalletyp.H, "1234567", "Södra ortopedmottagningen", context);
                    var organisation2 = SparaNyOrganisation("23456", Kostnadsstalletyp.H, "2345678", "Norra ortopedmottagningen", context);
                    var organisation3 = SparaNyOrganisation("34567", Kostnadsstalletyp.G, "3456789", "Tandläkarna i Väst, Gemensamma", context);
                    var organisation4 = SparaNyOrganisation("45678", Kostnadsstalletyp.H, "4567890", "Järvsö vård och ved", context);

                    SparaAdresser(context);

                    SparaNyttAnstalldAvtal(new Avtal
                    (
                        "334567349534",
                        "K01",
                        "Anställningsavtal X",
                        24,
                        1,
                        "Tandläkare",
                        true,
                        true,
                        true,
                        40,
                        38400,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person1, organisation1, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334567",
                        "K02",
                        "Anställningsavtal Y",
                        16,
                        1,
                        "Odontologkonsult",
                        true,
                        false,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person2, organisation1, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Ben läkare",
                        true,
                        false,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person3, organisation1, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        true,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person1, organisation2, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        false,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person1, organisation3, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        true,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person2, organisation3, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        false,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person3, organisation3, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        false,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person4, organisation3, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        false,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person5, organisation3, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        false,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person6, organisation3, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        false,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person7, organisation3, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        false,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person8, organisation3, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        false,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person9, organisation3, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        false,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person10, organisation3, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        true,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person4, organisation4, true, 100m, context);

                    SparaNyttKonsultAvtal(new Avtal
                    (
                        "349534334568",
                        "K32",
                        "Anställningsavtal XY",
                        18,
                        1,
                        "Tandläkare",
                        true,
                        false,
                        true,
                        40,
                        25600,
                        400,
                        DateTime.Now,
                        Metadata
                    ), person5, organisation4, true, 100m, context);

                }
            }
        }

        private static void SparaSystemdata(ODLDbContext context)
        {
            if (context.Database.SqlQuery<int>("SELECT COUNT(*) FROM Adress.Adressvariant").First() == 0)
            {
                //Adresstyp
                foreach (var enumValue in Enum.GetValues(typeof(Adresstyp)))
                context.Database.ExecuteSqlCommand("INSERT INTO Adress.Adresstyp VALUES(@Id, @Namn)", new SqlParameter("Id", (int)(Adresstyp)enumValue), new SqlParameter("Namn", ((Adresstyp)enumValue).Visningstext()));
                
                //Adressvariant
                foreach (var enumValue in Enum.GetValues(typeof(Adressvariant)))
                    context.Database.ExecuteSqlCommand(
                        "INSERT INTO Adress.Adressvariant VALUES(@Id, @Namn, @AdresstypFKId)",
                        new SqlParameter("Id", (int) (Adressvariant) enumValue),
                        new SqlParameter("Namn", ((Adressvariant) enumValue).Visningstext()),
                        new SqlParameter("AdresstypFKId", (int) ((Adressvariant) enumValue).Adresstyp()));
                context.SaveChanges();
            }
        }

        private Person SparaNyPerson(Person person, ODLDbContext context)
        {
            context.Person.AddOrUpdate(person);
            context.SaveChanges();
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

            var person3 = context.Person.ToList().Find(p => p.Personnummer == "198512123456");
            var adress3Lev = Adress.SkapaNyGatuadress("Hemvägen 3", "82240", "Järvsö", "Sverige", Adressvariant.Leveransadress, Metadata, person3);

            context.Adress.AddOrUpdate(
                adress1Hem,
                adress1Arbete,
                adress1MailPrivat,
                adress1MailArbete,
                adress1TelArbete,
                adress1TelPrivat,
                adress2Hem,
                adress3Lev
            );
            context.SaveChanges();

            var org = context.Organisation.ToList().Find(o => o.OrganisationsId == "1234567");
            var adressOrgArbete = Adress.SkapaNyGatuadress("Kungsgatan 3C", "16121", "Stockholm", "Sverige", Adressvariant.Leveransadress, Metadata, org);

            var org2 = context.Organisation.ToList().Find(o => o.OrganisationsId == "2345678");
            var adressOrgArbete2 = Adress.SkapaNyGatuadress("Storgatan 14B", "15790", "Göteborg", "Sverige", Adressvariant.Leveransadress, Metadata, org2);

            var org3 = context.Organisation.ToList().Find(o => o.OrganisationsId == "4567890");
            var adressOrgArbete3 = Adress.SkapaNyGatuadress("Arbetarvägen 23", "82240", "Järvsö", "Sverige", Adressvariant.Leveransadress, Metadata, org3);

            var org4 = context.Organisation.ToList().Find(o => o.OrganisationsId == "3456789");
            var adressOrgArbete4 = Adress.SkapaNyGatuadress("Drottinggatan 232", "45678", "Borås", "Sverige", Adressvariant.Leveransadress, Metadata, org4);

            context.Adress.AddOrUpdate(adressOrgArbete);
            context.Adress.AddOrUpdate(adressOrgArbete2);
            context.Adress.AddOrUpdate(adressOrgArbete3);
            context.Adress.AddOrUpdate(adressOrgArbete4);
            context.SaveChanges();
        }

        private Organisation SparaNyOrganisation(string kstNr, Kostnadsstalletyp typ, string organisationsId, string namn, ODLDbContext context)
        {
           
            var organisation = Organisation.SkapaNyResultatenhet(kstNr, typ, organisationsId, namn, Metadata);

            context.Organisation.AddOrUpdate(organisation);

            context.SaveChanges();

            return organisation;
        }

        private void SparaNyttAnstalldAvtal(Avtal avtal, Person person, Organisation organisation, bool huvudkostnadsstalle, decimal? procentuellFordelning, ODLDbContext context)
        {
            avtal.KopplaTillAnstalld(person);
            avtal.LaggTillOrganisation(organisation, huvudkostnadsstalle, procentuellFordelning);
            context.Avtal.AddOrUpdate(avtal);
            context.SaveChanges();
        }
        private void SparaNyttKonsultAvtal(Avtal avtal, Person person, Organisation organisation, bool huvudkostnadsstalle, decimal? procentuellFordelning, ODLDbContext context)
        {
            avtal.KopplaTillKonsult(person);
            avtal.LaggTillOrganisation(organisation, huvudkostnadsstalle, procentuellFordelning);
            context.Avtal.AddOrUpdate(avtal);
            context.SaveChanges();
        }
    }
}

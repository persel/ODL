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
                if (context.Person.ToList().Count == 0)
                {     
                    person1 = SparaNyPerson(new Person("Kalle", "Ove", "Nilsson", "197012123456", Metadata ), context);
                    person2 = SparaNyPerson(new Person("Marie", "Eva", "Persson", "196212303456", Metadata), context);
                    person3 = SparaNyPerson(new Person("Anders", "Ola", "Svensson", "197505223456", Metadata), context);

                   
                    SparaNyPerson(new Person ("Per", "Sven", "Andersson", "198512123456", Metadata ), context);
                    SparaNyPerson(new Person ("Stina", "Lisa", "Einarsson", "198512123456", Metadata ), context);
                    
                    
                }
                
                if (context.Organisation.ToList().Count == 0)
                {
                    var organisation1 = SparaNyOrganisation("12345", Kostnadsstalletyp.H, "1234567", "Södra ortopedmottagningen", context);
                    SparaNyOrganisation("23456", Kostnadsstalletyp.H, "2345678", "Norra ortopedmottagningen", context);
                    SparaNyOrganisation("34567", Kostnadsstalletyp.G, "3456789", "Tandläkarna i Väst, Gemensamma", context);
                    SparaNyOrganisation("45678", Kostnadsstalletyp.H, "4567890", "Järvsö vård och ved", context);

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

            context.Adress.AddOrUpdate(
                adress1Hem,
                adress1Arbete,
                adress1MailPrivat,
                adress1MailArbete,
                adress1TelArbete,
                adress1TelPrivat,
                adress2Hem
            );
            context.SaveChanges();

            var org = context.Organisation.ToList().Find(o => o.OrganisationsId == "1234567");
            var adressOrgArbete = Adress.SkapaNyGatuadress("Arbetarvägen 23", "82240", "Järvsö", "Sverige", Adressvariant.Leveransadress, Metadata, org);

            context.Adress.AddOrUpdate(adressOrgArbete);
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

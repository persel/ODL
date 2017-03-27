namespace ODL.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Adress.Adress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdressVariantFKId = c.Int(nullable: false),
                        UppdateradDatum = c.DateTime(),
                        UppdateradAv = c.String(maxLength: 10),
                        SkapadDatum = c.DateTime(nullable: false),
                        SkapadAv = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Adress.GatuAdress",
                c => new
                    {
                        AdressFKId = c.Int(nullable: false),
                        AdressRad1 = c.String(maxLength: 255),
                        AdressRad2 = c.String(maxLength: 255),
                        AdressRad3 = c.String(maxLength: 255),
                        AdressRad4 = c.String(maxLength: 255),
                        AdressRad5 = c.String(maxLength: 255),
                        Postnummer = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        Stad = c.String(nullable: false, maxLength: 255),
                        Land = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.AdressFKId)
                .ForeignKey("Adress.Adress", t => t.AdressFKId)
                .Index(t => t.AdressFKId);
            
            CreateTable(
                "Adress.Mail",
                c => new
                    {
                        AdressFKId = c.Int(nullable: false),
                        MailAdress = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.AdressFKId)
                .ForeignKey("Adress.Adress", t => t.AdressFKId)
                .Index(t => t.AdressFKId);
            
            CreateTable(
                "Adress.OrganisationAdress",
                c => new
                    {
                        AdressFKId = c.Int(nullable: false),
                        OrganisationFKId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdressFKId)
                .ForeignKey("Adress.Adress", t => t.AdressFKId)
                .Index(t => t.AdressFKId);
            
            CreateTable(
                "Adress.PersonAdress",
                c => new
                    {
                        AdressFKId = c.Int(nullable: false),
                        PersonFKId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdressFKId)
                .ForeignKey("Adress.Adress", t => t.AdressFKId)
                .Index(t => t.AdressFKId);
            
            CreateTable(
                "Adress.Telefon",
                c => new
                    {
                        AdressFKId = c.Int(nullable: false),
                        Telefonnummer = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.AdressFKId)
                .ForeignKey("Adress.Adress", t => t.AdressFKId)
                .Index(t => t.AdressFKId);
            
            CreateTable(
                "Adress.AdressVariant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Namn = c.String(nullable: false, maxLength: 255),
                        UppdateradDatum = c.DateTime(),
                        UppdateradAv = c.String(maxLength: 10),
                        SkapadDatum = c.DateTime(nullable: false),
                        SkapadAv = c.String(nullable: false, maxLength: 10),
                        AdressTypFKId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Person.AnstalldAvtal",
                c => new
                    {
                        AvtalFKId = c.Int(nullable: false),
                        PersonFKId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AvtalFKId)
                .ForeignKey("Person.Person", t => t.PersonFKId)
                .ForeignKey("Person.Avtal", t => t.AvtalFKId)
                .Index(t => t.AvtalFKId)
                .Index(t => t.PersonFKId);
            
            CreateTable(
                "Person.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KallsystemId = c.String(nullable: false, maxLength: 25),
                        Fornamn = c.String(nullable: false, maxLength: 255),
                        Mellannamn = c.String(maxLength: 255),
                        Efternamn = c.String(nullable: false, maxLength: 255),
                        Personnummer = c.String(nullable: false, maxLength: 12),
                        UppdateradDatum = c.DateTime(),
                        UppdateradAv = c.String(maxLength: 10),
                        SkapadDatum = c.DateTime(nullable: false),
                        SkapadAv = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Person.KonsultAvtal",
                c => new
                    {
                        AvtalFKId = c.Int(nullable: false),
                        PersonFKId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AvtalFKId)
                .ForeignKey("Person.Avtal", t => t.AvtalFKId)
                .ForeignKey("Person.Person", t => t.PersonFKId)
                .Index(t => t.AvtalFKId)
                .Index(t => t.PersonFKId);
            
            CreateTable(
                "Person.Avtal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KallsystemId = c.String(nullable: false, maxLength: 25),
                        Avtalskod = c.String(maxLength: 50),
                        Avtalstext = c.String(maxLength: 50),
                        ArbetstidVecka = c.Int(),
                        Befkod = c.Int(),
                        BefText = c.String(maxLength: 50),
                        Aktiv = c.Boolean(),
                        Ansvarig = c.Boolean(),
                        Chef = c.Boolean(),
                        TjledigFran = c.DateTime(),
                        TjledigTom = c.DateTime(),
                        Fproc = c.Decimal(precision: 18, scale: 2),
                        DeltidFranvaro = c.String(maxLength: 10),
                        FranvaroProcent = c.Decimal(precision: 18, scale: 2),
                        SjukP = c.String(maxLength: 10),
                        GrundArbtidVecka = c.Decimal(precision: 18, scale: 2),
                        Avtalstyp = c.Byte(),
                        Lon = c.Int(),
                        LonDatum = c.DateTime(),
                        LoneTyp = c.String(maxLength: 10),
                        LoneTillagg = c.Int(),
                        TimLon = c.Int(),
                        Anstallningsdatum = c.DateTime(),
                        Avgangsdatum = c.DateTime(),
                        UppdateradDatum = c.DateTime(),
                        UppdateradAv = c.String(maxLength: 10),
                        SkapadDatum = c.DateTime(nullable: false),
                        SkapadAv = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Person.OrganisationAvtal",
                c => new
                    {
                        AvtalFKId = c.Int(nullable: false),
                        OrganisationFKId = c.Int(nullable: false),
                        ProcentuellFordelning = c.Decimal(precision: 5, scale: 2),
                        Huvudkostnadsstalle = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.AvtalFKId, t.OrganisationFKId })
                .ForeignKey("Organisation.Organisation", t => t.OrganisationFKId)
                .ForeignKey("Person.Avtal", t => t.AvtalFKId)
                .Index(t => t.AvtalFKId)
                .Index(t => t.OrganisationFKId);
            
            CreateTable(
                "Organisation.Organisation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganisationsId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Namn = c.String(maxLength: 100),
                        IngarIOrganisationFKId = c.Int(),
                        UppdateradDatum = c.DateTime(),
                        UppdateradAv = c.String(maxLength: 10),
                        SkapadDatum = c.DateTime(nullable: false),
                        SkapadAv = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Organisation.Organisation", t => t.IngarIOrganisationFKId)
                .Index(t => t.IngarIOrganisationFKId);
            
            CreateTable(
                "Organisation.Resultatenhet",
                c => new
                    {
                        OrganisationFKId = c.Int(nullable: false),
                        KstNr = c.Int(nullable: false),
                        Typ = c.String(maxLength: 10),
                        UppdateradDatum = c.DateTime(),
                        UppdateradAv = c.String(maxLength: 10),
                        SkapadDatum = c.DateTime(nullable: false),
                        SkapadAv = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.OrganisationFKId)
                .ForeignKey("Organisation.Organisation", t => t.OrganisationFKId)
                .Index(t => t.OrganisationFKId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Person.AnstalldAvtal", "AvtalFKId", "Person.Avtal");
            DropForeignKey("Person.KonsultAvtal", "PersonFKId", "Person.Person");
            DropForeignKey("Person.KonsultAvtal", "AvtalFKId", "Person.Avtal");
            DropForeignKey("Person.OrganisationAvtal", "AvtalFKId", "Person.Avtal");
            DropForeignKey("Organisation.Organisation", "IngarIOrganisationFKId", "Organisation.Organisation");
            DropForeignKey("Organisation.Resultatenhet", "OrganisationFKId", "Organisation.Organisation");
            DropForeignKey("Person.OrganisationAvtal", "OrganisationFKId", "Organisation.Organisation");
            DropForeignKey("Person.AnstalldAvtal", "PersonFKId", "Person.Person");
            DropForeignKey("Adress.Telefon", "AdressFKId", "Adress.Adress");
            DropForeignKey("Adress.PersonAdress", "AdressFKId", "Adress.Adress");
            DropForeignKey("Adress.OrganisationAdress", "AdressFKId", "Adress.Adress");
            DropForeignKey("Adress.Mail", "AdressFKId", "Adress.Adress");
            DropForeignKey("Adress.GatuAdress", "AdressFKId", "Adress.Adress");
            DropIndex("Organisation.Resultatenhet", new[] { "OrganisationFKId" });
            DropIndex("Organisation.Organisation", new[] { "IngarIOrganisationFKId" });
            DropIndex("Person.OrganisationAvtal", new[] { "OrganisationFKId" });
            DropIndex("Person.OrganisationAvtal", new[] { "AvtalFKId" });
            DropIndex("Person.KonsultAvtal", new[] { "PersonFKId" });
            DropIndex("Person.KonsultAvtal", new[] { "AvtalFKId" });
            DropIndex("Person.AnstalldAvtal", new[] { "PersonFKId" });
            DropIndex("Person.AnstalldAvtal", new[] { "AvtalFKId" });
            DropIndex("Adress.Telefon", new[] { "AdressFKId" });
            DropIndex("Adress.PersonAdress", new[] { "AdressFKId" });
            DropIndex("Adress.OrganisationAdress", new[] { "AdressFKId" });
            DropIndex("Adress.Mail", new[] { "AdressFKId" });
            DropIndex("Adress.GatuAdress", new[] { "AdressFKId" });
            DropTable("Organisation.Resultatenhet");
            DropTable("Organisation.Organisation");
            DropTable("Person.OrganisationAvtal");
            DropTable("Person.Avtal");
            DropTable("Person.KonsultAvtal");
            DropTable("Person.Person");
            DropTable("Person.AnstalldAvtal");
            DropTable("Adress.AdressVariant");
            DropTable("Adress.Telefon");
            DropTable("Adress.PersonAdress");
            DropTable("Adress.OrganisationAdress");
            DropTable("Adress.Mail");
            DropTable("Adress.GatuAdress");
            DropTable("Adress.Adress");
        }
    }
}

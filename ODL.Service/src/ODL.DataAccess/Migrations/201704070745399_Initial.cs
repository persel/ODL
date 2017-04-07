using ODL.DataAccess.Migrations.Custom;

namespace ODL.DataAccess.Migrations
{
    
    public partial class Initial : CustomMigrations
    {
        public override void Up()
        {
            CreateTable(
                "Adress.Adress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UppdateradDatum = c.DateTime(),
                        UppdateradAv = c.String(maxLength: 10, unicode: false),
                        SkapadDatum = c.DateTime(nullable: false),
                        SkapadAv = c.String(nullable: false, maxLength: 10, unicode: false),
                        AdressVariantFKId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Adress.AdressVariant", t => t.AdressVariantFKId)
                .Index(t => t.AdressVariantFKId);
            
            CreateTable(
                "Adress.AdressVariant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Namn = c.String(nullable: false, maxLength: 255, unicode: false),
                        AdressTypFKId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Adress.GatuAdress",
                c => new
                    {
                        AdressFKId = c.Int(nullable: false),
                        AdressRad1 = c.String(nullable: false, maxLength: 255),
                        AdressRad2 = c.String(maxLength: 255),
                        AdressRad3 = c.String(maxLength: 255),
                        AdressRad4 = c.String(maxLength: 255),
                        AdressRad5 = c.String(maxLength: 255),
                        Postnummer = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        Stad = c.String(nullable: false, maxLength: 255),
                        Land = c.String(maxLength: 255, unicode: false),
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
                        Telefonnummer = c.String(nullable: false, maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => t.AdressFKId)
                .ForeignKey("Adress.Adress", t => t.AdressFKId)
                .Index(t => t.AdressFKId);
            
            CreateTable(
                "Avtal.Avtal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KallsystemId = c.String(nullable: false, maxLength: 25),
                        Avtalskod = c.String(maxLength: 50, unicode: false),
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
                        UppdateradAv = c.String(maxLength: 10, unicode: false),
                        SkapadDatum = c.DateTime(nullable: false),
                        SkapadAv = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Avtal.AnstalldAvtal",
                c => new
                    {
                        AvtalId = c.Int(nullable: false),
                        PersonFKId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AvtalId)
                .ForeignKey("Avtal.Avtal", t => t.AvtalId)
                .Index(t => t.AvtalId);
            
            CreateTable(
                "Avtal.KonsultAvtal",
                c => new
                    {
                        AvtalId = c.Int(nullable: false),
                        PersonFKId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AvtalId)
                .ForeignKey("Avtal.Avtal", t => t.AvtalId)
                .Index(t => t.AvtalId);
            
            CreateTable(
                "Avtal.OrganisationAvtal",
                c => new
                    {
                        AvtalFKId = c.Int(nullable: false),
                        OrganisationFKId = c.Int(nullable: false),
                        ProcentuellFordelning = c.Decimal(precision: 5, scale: 2),
                        Huvudkostnadsstalle = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.AvtalFKId, t.OrganisationFKId })
                .ForeignKey("Avtal.Avtal", t => t.AvtalFKId)
                .Index(t => t.AvtalFKId);
            
            CreateTable(
                "Organisation.Organisation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganisationsId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Namn = c.String(maxLength: 255),
                        IngarIOrganisationFKId = c.Int(),
                        UppdateradDatum = c.DateTime(),
                        UppdateradAv = c.String(maxLength: 10, unicode: false),
                        SkapadDatum = c.DateTime(nullable: false),
                        SkapadAv = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Organisation.Organisation", t => t.IngarIOrganisationFKId)
                .Index(t => t.IngarIOrganisationFKId);
            
            CreateTable(
                "Organisation.Resultatenhet",
                c => new
                    {
                        OrganisationFKId = c.Int(nullable: false),
                        KstNr = c.String(maxLength: 6, unicode: false),
                        Typ = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.OrganisationFKId)
                .ForeignKey("Organisation.Organisation", t => t.OrganisationFKId)
                .Index(t => t.OrganisationFKId);
            
            CreateTable(
                "Person.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KallsystemId = c.String(nullable: false, maxLength: 25),
                        Fornamn = c.String(nullable: false, maxLength: 255),
                        Mellannamn = c.String(nullable: false, maxLength: 255),
                        Efternamn = c.String(nullable: false, maxLength: 255),
                        Personnummer = c.String(nullable: false, maxLength: 12),
                        UppdateradDatum = c.DateTime(),
                        UppdateradAv = c.String(maxLength: 10, unicode: false),
                        SkapadDatum = c.DateTime(nullable: false),
                        SkapadAv = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id);

            AddForeignKeysWithoutNavigationPropertyRelations();
            AddNonMappedTables();
        }

        public override void Down()
        {
            DropForeignKeysWithoutNavigationPropertyRelations();
            DropNonMappedTables();

            DropForeignKey("Organisation.Organisation", "IngarIOrganisationFKId", "Organisation.Organisation");
            DropForeignKey("Organisation.Resultatenhet", "OrganisationFKId", "Organisation.Organisation");
            DropForeignKey("Avtal.OrganisationAvtal", "AvtalFKId", "Avtal.Avtal");
            DropForeignKey("Avtal.KonsultAvtal", "AvtalId", "Avtal.Avtal");
            DropForeignKey("Avtal.AnstalldAvtal", "AvtalId", "Avtal.Avtal");
            DropForeignKey("Adress.Telefon", "AdressFKId", "Adress.Adress");
            DropForeignKey("Adress.PersonAdress", "AdressFKId", "Adress.Adress");
            DropForeignKey("Adress.OrganisationAdress", "AdressFKId", "Adress.Adress");
            DropForeignKey("Adress.Mail", "AdressFKId", "Adress.Adress");
            DropForeignKey("Adress.GatuAdress", "AdressFKId", "Adress.Adress");
            DropForeignKey("Adress.Adress", "AdressVariantFKId", "Adress.AdressVariant");
            DropIndex("Organisation.Resultatenhet", new[] { "OrganisationFKId" });
            DropIndex("Organisation.Organisation", new[] { "IngarIOrganisationFKId" });
            DropIndex("Avtal.OrganisationAvtal", new[] { "AvtalFKId" });
            DropIndex("Avtal.KonsultAvtal", new[] { "AvtalId" });
            DropIndex("Avtal.AnstalldAvtal", new[] { "AvtalId" });
            DropIndex("Adress.Telefon", new[] { "AdressFKId" });
            DropIndex("Adress.PersonAdress", new[] { "AdressFKId" });
            DropIndex("Adress.OrganisationAdress", new[] { "AdressFKId" });
            DropIndex("Adress.Mail", new[] { "AdressFKId" });
            DropIndex("Adress.GatuAdress", new[] { "AdressFKId" });
            DropIndex("Adress.Adress", new[] { "AdressVariantFKId" });
            DropTable("Person.Person");
            DropTable("Organisation.Resultatenhet");
            DropTable("Organisation.Organisation");
            DropTable("Avtal.OrganisationAvtal");
            DropTable("Avtal.KonsultAvtal");
            DropTable("Avtal.AnstalldAvtal");
            DropTable("Avtal.Avtal");
            DropTable("Adress.Telefon");
            DropTable("Adress.PersonAdress");
            DropTable("Adress.OrganisationAdress");
            DropTable("Adress.Mail");
            DropTable("Adress.GatuAdress");
            DropTable("Adress.AdressVariant");
            DropTable("Adress.Adress");
        }
    }
}

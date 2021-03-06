﻿using System.Data.Entity.Migrations;

namespace ODL.DataAccess.Migrations.Custom
{
    public abstract class CustomMigrations : DbMigration
    {
        protected void AddForeignKeysWithoutNavigationPropertyRelations()
        {
            AddForeignKey("Avtal.KonsultAvtal", "PersonFKId", "Person.Person", "Id");
            AddForeignKey("Avtal.AnstalldAvtal", "PersonFKId", "Person.Person", "Id");
            AddForeignKey("Avtal.OrganisationAvtal", "OrganisationFKId", "Organisation.Organisation", "Id");

            AddForeignKey("Adress.PersonAdress", "PersonFKId", "Person.Person", "Id");
            AddForeignKey("Adress.OrganisationAdress", "OrganisationFKId", "Organisation.Organisation", "Id");

            AddForeignKey("Adress.Adress", "AdressvariantFKId", "Adress.Adressvariant", "Id");
            AddForeignKey("Adress.Adressvariant", "AdresstypFKId", "Adress.Adresstyp", "Id");

        }

        protected void AddNonMappedTables()
        {

            CreateTable(
                    "Adress.Adressvariant",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Namn = c.String(nullable: false, maxLength: 100, unicode: false),
                        AdresstypFKId = c.Int(nullable: false, identity: false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "Adress.Adresstyp",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Namn = c.String(nullable: false, maxLength: 100, unicode:false)
                    })
                .PrimaryKey(t => t.Id);
            
        }

        protected void DropForeignKeysWithoutNavigationPropertyRelations()
        {
            DropForeignKey("Avtal.KonsultAvtal", "PersonFKId", "Person.Person");
            DropForeignKey("Avtal.AnstalldAvtal", "PersonFKId", "Person.Person");
            DropForeignKey("Avtal.OrganisationAvtal", "OrganisationFKId", "Organisation.Organisation");

            DropForeignKey("Adress.PersonAdress", "PersonFKId", "Person.Person");
            DropForeignKey("Adress.OrganisationAdress", "OrganisationFKId", "Organisation.Organisation");

            DropForeignKey("Adress.Adress", "AdressvariantFKId", "Adress.Adressvariant");
            DropForeignKey("Adress.Adressvariant", "AdresstypFKId", "Adress.Adresstyp");

        }

        protected void DropNonMappedTables()
        {
            DropForeignKey("Adress.Adressvariant", "AdressTypFKId", "Adress.Adresstyp");
            DropTable("Adress.Adressvariant");
            DropTable("Adress.Adresstyp");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODL.DomainModel;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Mappningar
{
    class Mappningar
    {


    }

    public class PersonMappning : EntityTypeConfiguration<Person>
    {
        public PersonMappning()
        {
            ToTable("Person.Person");
            HasKey(m => m.Id).Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Fornamn).IsRequired().HasMaxLength(255);
            Property(m => m.Mellannamn).IsRequired().HasMaxLength(255);
            Property(m => m.Efternamn).IsRequired().HasMaxLength(255);
            Property(m => m.KallsystemId).IsRequired().HasMaxLength(25);
            Property(m => m.Personnummer).IsRequired().HasMaxLength(12);
        }
    }

    public class OrganisationAvtalMappning : EntityTypeConfiguration<OrganisationAvtal>
    {
        public OrganisationAvtalMappning()
        {
            //ToTable("Person.OrganisationAvtal");
            //HasKey(m => m.AvtalFKId)
            //    .Property(m => m.AvtalFKId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //HasKey(m => m.OrganisationFKId).Property(m => m.OrganisationFKId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //Property(t => t.AvtalFKId).HasColumnName("AvtalFKId").HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_AvtalFKId", 1) { IsUnique = true }));
            //Property(t => t.OrganisationFKId).HasColumnName("OrganisationFKId").HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_OrganisationFKId", 2) { IsUnique = true }));
        }
    }
}

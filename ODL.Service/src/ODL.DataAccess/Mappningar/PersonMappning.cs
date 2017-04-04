using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Mappningar
{
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
}
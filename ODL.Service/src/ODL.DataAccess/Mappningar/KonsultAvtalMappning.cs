using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Mappningar
{
    public class KonsultAvtalMappning : EntityTypeConfiguration<KonsultAvtal>
    {
        public KonsultAvtalMappning()
        {
            ToTable("Person.KonsultAvtal");
            HasKey(m => m.AvtalId)
                .Property(m => m.AvtalId).HasColumnName("AvtalId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(m => m.PersonId).HasColumnName("PersonFKId");
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Avtal;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Mappningar
{
    public class KonsultAvtalMappning : EntityTypeConfiguration<KonsultAvtal>
    {
        public KonsultAvtalMappning()
        {
            ToTable("Avtal.KonsultAvtal");
            HasKey(m => m.AvtalId)
                .Property(m => m.AvtalId).HasColumnName("AvtalId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(m => m.PersonId).HasColumnName("PersonFKId");

            HasRequired(p => p.Avtal)
                .WithOptional(p => p.KonsultAvtal);
        }
    }
}
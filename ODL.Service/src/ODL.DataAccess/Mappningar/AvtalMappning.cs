using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Mappningar
{
    public class AvtalMappning : EntityTypeConfiguration<Avtal>
    {
        public AvtalMappning()
        {
            ToTable("Person.Avtal");
            HasKey(m => m.Id).Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.KallsystemId).IsRequired().HasMaxLength(25);
            Property(m => m.Avtalskod).HasMaxLength(50);
            Property(m => m.Avtalstext).HasMaxLength(50);
            Property(m => m.BefText).HasMaxLength(50);
            Property(m => m.DeltidFranvaro).HasMaxLength(10);
            Property(m => m.SjukP).HasMaxLength(10);
            Property(m => m.LoneTyp).HasMaxLength(10);
            Property(m => m.LoneTyp).HasMaxLength(10);
        }
    }
}
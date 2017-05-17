using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Avtal;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Mappningar
{
    public class AnstalldAvtalMappning : EntityTypeConfiguration<AnstalldAvtal>
    {
        public AnstalldAvtalMappning()
        {
            ToTable("Avtal.AnstalldAvtal");
            HasKey(m => m.AvtalId)
                .Property(m => m.AvtalId).HasColumnName("AvtalId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(m => m.PersonId).HasColumnName("PersonFKId");

            HasRequired(p => p.Avtal)
                .WithOptional(p => p.AnstalldAvtal);
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel;
using ODL.DomainModel.Organisation;

namespace ODL.DataAccess.Mappningar
{
    public class OrganisationAvtalMappning : EntityTypeConfiguration<OrganisationAvtal>
    {
        public OrganisationAvtalMappning()
        {
            ToTable("Avtal.OrganisationAvtal");

            HasKey(k => new {k.OrganisationId, k.AvtalId});

            Property(e => e.OrganisationId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnName("OrganisationFKId");
            Property(e => e.AvtalId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnName("AvtalFKId");

            Property(e => e.ProcentuellFordelning).HasPrecision(5, 2);

        }
    }
}
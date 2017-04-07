using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Organisation;

namespace ODL.DataAccess.Mappningar
{
    public class OrganisationMappning : EntityTypeConfiguration<Organisation>
    {
        public OrganisationMappning()
        {
            ToTable("Organisation.Organisation");
            HasKey(m => m.Id).Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.IngarIOrganisationId).HasColumnName("IngarIOrganisationFKId");
            Property(m => m.OrganisationsId).IsRequired().HasMaxLength(50).IsUnicode(false);
            Property(m => m.Namn).HasMaxLength(255);
            
            HasMany(e => e.Underliggande)
                .WithOptional(e => e.Overordnad)
                .HasForeignKey(e => e.IngarIOrganisationId);

            HasOptional(e => e.Resultatenhet)
                .WithRequired(e => e.Organisation);
        }
    }
}
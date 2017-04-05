using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel;

namespace ODL.DataAccess.Mappningar
{
    public class OrganisationAvtalMappning : EntityTypeConfiguration<OrganisationAvtal>
    {
        public OrganisationAvtalMappning()
        {
            ToTable("Person.OrganisationAvtal");

            HasKey(k => new {k.OrganisationId, k.AvtalId});

            Property(e => e.OrganisationId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnName("OrganisationFKId");
            Property(e => e.AvtalId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnName("AvtalFKId");

            Property(e => e.ProcentuellFordelning).HasPrecision(5, 2);

            //Property(t => t.AvtalId).HasColumnName("AvtalId").HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_AvtalFKId", 1) { IsUnique = true }));
            //Property(t => t.OrganisationId).HasColumnName("OrganisationId").HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_OrganisationFKId", 2) { IsUnique = true }));
        }
    }
}
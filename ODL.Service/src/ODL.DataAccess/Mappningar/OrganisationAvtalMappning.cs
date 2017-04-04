using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel;

namespace ODL.DataAccess.Mappningar
{
    public class OrganisationAvtalMappning : EntityTypeConfiguration<OrganisationAvtal>
    {
        public OrganisationAvtalMappning()
        {
            //ToTable("Person.OrganisationAvtal");
            //HasKey(m => m.AvtalId)
            //    .Property(m => m.AvtalId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //HasKey(m => m.OrganisationId).Property(m => m.OrganisationId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //Property(t => t.AvtalId).HasColumnName("AvtalId").HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_AvtalFKId", 1) { IsUnique = true }));
            //Property(t => t.OrganisationId).HasColumnName("OrganisationId").HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_OrganisationFKId", 2) { IsUnique = true }));
        }
    }
}
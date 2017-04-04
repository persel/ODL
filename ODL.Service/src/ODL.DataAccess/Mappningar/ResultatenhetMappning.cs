using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Organisation;

namespace ODL.DataAccess.Mappningar
{
    public class ResultatenhetMappning : EntityTypeConfiguration<Resultatenhet>
    {
        public ResultatenhetMappning()
        {
            ToTable("Organisation.Resultatenhet");
            HasKey(m => m.OrganisationId)
                .Property(m => m.OrganisationId).HasColumnName("OrganisationFKId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            
            Property(m => m.Typ).HasMaxLength(10);

        }
    }
}
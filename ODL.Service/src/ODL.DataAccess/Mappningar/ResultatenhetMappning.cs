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
            
            Property(m => m.KstNr).HasMaxLength(6).IsUnicode(false);
            Ignore(m => m.Typ);
            Property(m => m.KostnadsstalletypString).HasColumnName("Typ").HasMaxLength(1).IsUnicode(false).IsRequired();

        }
    }
}
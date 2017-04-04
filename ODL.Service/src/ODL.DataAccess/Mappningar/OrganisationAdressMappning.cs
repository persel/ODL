using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Adress;

namespace ODL.DataAccess.Mappningar
{
    public class OrganisationAdressMappning : EntityTypeConfiguration<OrganisationAdress>
    {
        public OrganisationAdressMappning()
        {
            ToTable("Adress.OrganisationAdress");
            HasKey(m => m.AdressId)
                .Property(m => m.AdressId)
                .HasColumnName("AdressFKId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(m => m.OrganisationId).HasColumnName("OrganisationFKId");
        }
    }
}
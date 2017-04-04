using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Adress;

namespace ODL.DataAccess.Mappningar
{
    public class AdressVariantMappning : EntityTypeConfiguration<AdressVariant>
    {
        public AdressVariantMappning()
        {
            ToTable("Adress.AdressVariant");
            HasKey(m => m.Id).Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Namn).IsRequired().HasMaxLength(255);

            Property(m => m.AdressTyp).HasColumnName("AdressTypFKId");
        }
    }
}
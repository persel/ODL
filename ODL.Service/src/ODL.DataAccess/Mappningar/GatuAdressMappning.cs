using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Adress;

namespace ODL.DataAccess.Mappningar
{
    public class GatuAdressMappning : EntityTypeConfiguration<GatuAdress>
    {
        public GatuAdressMappning()
        {

            ToTable("Adress.GatuAdress");
            HasKey(m => m.AdressId)
                .Property(m => m.AdressId)
                .HasColumnName("AdressFKId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(m => m.AdressRad1).IsRequired().HasMaxLength(255);
            Property(m => m.AdressRad2).HasMaxLength(255);
            Property(m => m.AdressRad3).HasMaxLength(255);
            Property(m => m.AdressRad4).HasMaxLength(255);
            Property(m => m.AdressRad5).HasMaxLength(255);
            Property(m => m.Stad).IsRequired().HasMaxLength(255);
            Property(m => m.Land).HasMaxLength(255);

            Property(m => m.Postnummer).IsRequired().HasMaxLength(5).IsFixedLength();
            
        }
    }
}
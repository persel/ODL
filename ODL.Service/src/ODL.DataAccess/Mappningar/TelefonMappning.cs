using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Adress;

namespace ODL.DataAccess.Mappningar
{
    public class TelefonMappning : EntityTypeConfiguration<Telefon>
    {
        public TelefonMappning()
        {
            ToTable("Adress.Telefon");
            HasKey(m => m.AdressId)
                .Property(m => m.AdressId)
                .HasColumnName("AdressFKId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(m => m.Telefonnummer).IsRequired().HasMaxLength(25).IsUnicode(false);
        }
    }
}
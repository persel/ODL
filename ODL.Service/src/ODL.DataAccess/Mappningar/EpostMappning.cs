using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Adress;

namespace ODL.DataAccess.Mappningar
{
    public class EpostMappning : EntityTypeConfiguration<Epost>
    {
        public EpostMappning()
        {
            ToTable("Adress.Epost");
            HasKey(m => m.AdressId)
                .Property(m => m.AdressId)
                .HasColumnName("AdressFKId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(m => m.EpostAdress).IsRequired().HasMaxLength(255).IsUnicode(false); 
        }
    }
}
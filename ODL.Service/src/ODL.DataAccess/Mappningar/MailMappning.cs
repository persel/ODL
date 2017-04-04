using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Adress;

namespace ODL.DataAccess.Mappningar
{
    public class MailMappning : EntityTypeConfiguration<Mail>
    {
        public MailMappning()
        {
            ToTable("Adress.Mail");
            HasKey(m => m.AdressId)
                .Property(m => m.AdressId)
                .HasColumnName("AdressFKId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(m => m.MailAdress).IsRequired().HasMaxLength(255).IsUnicode(false); 
        }
    }
}
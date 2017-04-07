using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Adress;

namespace ODL.DataAccess.Mappningar
{
    public class AdressMappning : EntityTypeConfiguration<Adress>
    {
        public AdressMappning()
        {
            ToTable("Adress.Adress");
            HasKey(a => a.Id).Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Ignore(a => a.IsNew);

            HasRequired(m => m.AdressVariant).WithMany().Map(m => m.MapKey("AdressVariantFKId")).WillCascadeOnDelete(false);

            HasOptional(e => e.Gatuadress)
                .WithRequired(e => e.Adress);

            HasOptional(e => e.Mail)
                .WithRequired(e => e.Adress);

            HasOptional(e => e.OrganisationAdress)
                .WithRequired(e => e.Adress);

            HasOptional(e => e.PersonAdress)
                .WithRequired(e => e.Adress);

            HasOptional(e => e.Telefon)
                .WithRequired(e => e.Adress);
        }
    }
}
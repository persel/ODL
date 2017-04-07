using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Adress;

namespace ODL.DataAccess.Mappningar
{
    public class PersonAdressMappning : EntityTypeConfiguration<PersonAdress>
    {
        public PersonAdressMappning()
        {
            ToTable("Adress.PersonAdress");
            HasKey(m => m.AdressId)
                .Property(m => m.AdressId)
                .HasColumnName("AdressFKId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(m => m.PersonId).HasColumnName("PersonFKId");
        }
    }
}
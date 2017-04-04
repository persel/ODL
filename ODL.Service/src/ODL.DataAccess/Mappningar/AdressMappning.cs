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
            HasKey(m => m.Id).Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
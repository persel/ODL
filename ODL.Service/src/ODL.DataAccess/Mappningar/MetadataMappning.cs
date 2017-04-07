using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Common;

namespace ODL.DataAccess.Mappningar
{
    public class MetadataMappning : ComplexTypeConfiguration<Metadata>
    {
        public MetadataMappning()
        {
            Property(m => m.UppdateradDatum).HasColumnName("UppdateradDatum");
            Property(m => m.UppdateradAv).HasMaxLength(10).HasColumnName("UppdateradAv").IsUnicode(false);
            Property(m => m.SkapadDatum).IsRequired().HasColumnName("SkapadDatum");
            Property(m => m.SkapadAv).IsRequired().HasMaxLength(10).HasColumnName("SkapadAv").IsUnicode(false);
        }
    }
}
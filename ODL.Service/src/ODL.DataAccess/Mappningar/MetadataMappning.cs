using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Common;

namespace ODL.DataAccess.Mappningar
{
    public class MetadataMappning : ComplexTypeConfiguration<Metadata>
    {
        public MetadataMappning()
        {
        }




        // [ComplexType]

        /*
                 [Column("UppdateradDatum")]
        public DateTime? UppdateradDatum { get; set; }
        
        [StringLength(10)]
        [Column("UppdateradAv")]
        public string UppdateradAv { get; set; }

        [Column("SkapadDatum")]
        public DateTime SkapadDatum { get; set; }

        [Required]
        [StringLength(10)]
        [Column("SkapadAv")]
        public string SkapadAv { get; set; }*/




    }
}
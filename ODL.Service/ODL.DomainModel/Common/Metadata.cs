using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Common
{
    [ComplexType]
    public class Metadata
    {
        public Metadata(){}
        public Metadata(DateTime? uppdateradDatum, string uppdateradAv, DateTime skapadDatum, string skapadAv)
        {
            UppdateradDatum = uppdateradDatum;
            UppdateradAv = uppdateradAv;
            SkapadDatum = skapadDatum;
            SkapadAv = skapadAv;
        }

        public Metadata(DateTime skapadDatum, string skapadAv)
        {
            SkapadDatum = skapadDatum;
            SkapadAv = skapadAv;
        }

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
        public string SkapadAv { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODL.DomainModel.Common
{
    [ComplexType]
    public class Metadata
    {
        //[Column("UppdateradDatum")]
        public DateTime UppdateradDatum { get; set; }
        
        [StringLength(10)]
        //[Column("UppdateradAv")]
        public string UppdateradAv { get; set; }

        [Required]
        //[Column("SkapadDatum")]
        public DateTime SkapadDatum { get; set; }

        [Required]
        [StringLength(10)]
        //[Column("SkapadAv")]
        public string SkapadAv { get; set; }
    }
}

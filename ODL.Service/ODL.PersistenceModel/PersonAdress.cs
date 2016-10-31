using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PTJ.DataLayer.Models
{
    [Table("PersonAdress", Schema = "Adress")]
    public partial class PersonAdress
    {
        [Key]
        public long Id { get; set; }
        public long PersonFkid { get; set; }
        public long AdressFkid { get; set; }
        public string UpdateradAv { get; set; }
        public DateTime? SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }

        //public virtual Adress AdressFk { get; set; }
        //public virtual Person PersonFk { get; set; }
    }
}

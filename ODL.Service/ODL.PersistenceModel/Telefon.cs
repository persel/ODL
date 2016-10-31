using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTJ.DataLayer.Models
{
    [Table("Telefon", Schema = "Adress")]
    public partial class Telefon
    {
        public long Id { get; set; }
        public long AdressFkid { get; set; }
        public decimal TelefonNummer { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }
        public string UpdateradAv { get; set; }

        //public virtual Adress AdressFk { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTJ.DataLayer.Models
{
    [Table("Mail", Schema = "Adress")]
    public partial class Mail
    {
        [Key]
        public long Id { get; set; }

        public long AdressFkid { get; set; }
        public string MailAdress { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }
        public string UpdateradAv { get; set; }

        //public virtual Adress AdressFk { get; set; }
    }
}

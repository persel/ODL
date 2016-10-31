using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DataAccess.Models
{
    [Table("Mail", Schema = "Adress")]
    public partial class Mail
    {
        [Key]
        public int Id { get; set; }

        public int AdressFkid { get; set; }
        public string MailAdress { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }
        public string UpdateradAv { get; set; }

        //public virtual Adress AdressFk { get; set; }
    }
}

using ODL.DomainModel.Common;

namespace ODL.DomainModel.Adress
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adress.Mail")]
    public partial class Mail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdressFKId { get; set; }

        [Required]
        [StringLength(255)]
        public string MailAdress { get; set; }

        
        public virtual Adress Adress { get; set; }
    }
}

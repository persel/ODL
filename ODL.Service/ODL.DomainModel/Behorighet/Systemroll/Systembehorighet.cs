using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Systemroll
{

    [Table("Behorighet.Systembehorighet")]
    public partial class Systembehorighet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("SystemanvandargruppFKId")]
        public int SystemanvandargruppId { get; set; }

        [Column("AnvandareFKId")]
        public int AnvandareId { get; set; }

        public DateTime? GallerFran { get; set; }

        public DateTime? GallerTill { get; set; }

        public virtual Anvandare Anvandare { get; set; }
    }
}

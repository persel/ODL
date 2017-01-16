using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Systemroll
{

    [Table("Behorighet.Systembehorighet")]
    public partial class Systembehorighet
    {
        public int Id { get; set; }

        public int SystemanvandargruppFKId { get; set; }

        public int AnvandareFKId { get; set; }

        public DateTime? GallerFran { get; set; }

        public DateTime? GallerTill { get; set; }

        public virtual Anvandare Anvandare { get; set; }
    }
}

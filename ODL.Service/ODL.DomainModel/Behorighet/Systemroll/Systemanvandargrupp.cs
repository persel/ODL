using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Systemroll
{

    [Table("Behorighet.Systemanvandargrupp")]
    public partial class Systemanvandargrupp
    {
        public int Id { get; set; }

        public int SystemFKId { get; set; }

        public int BehorighetsnivaFKId { get; set; }

        [Required]
        [StringLength(50)]
        public string Namn { get; set; }

        public virtual Behorighetsniva Behorighetsniva { get; set; }

        public virtual System System { get; set; }
    }
}

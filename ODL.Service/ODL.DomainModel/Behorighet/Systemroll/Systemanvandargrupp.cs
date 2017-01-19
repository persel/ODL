using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Systemroll
{

    [Table("Behorighet.Systemanvandargrupp")]
    public partial class Systemanvandargrupp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("SystemFKId")]
        public int SystemId { get; set; }

        [Column("BehorighetsnivaFKId")]
        public int BehorighetsnivaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Namn { get; set; }

        public virtual Behorighetsniva Behorighetsniva { get; set; }

        public virtual System System { get; set; }
    }
}

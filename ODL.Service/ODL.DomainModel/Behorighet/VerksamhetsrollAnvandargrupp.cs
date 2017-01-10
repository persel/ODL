using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ODL.DomainModel.Behorighet.Systemroll;

namespace ODL.DomainModel.Behorighet
{

    [Table("Behorighet.VerksamhetsrollAnvandargrupp")]
    public partial class VerksamhetsrollAnvandargrupp
    {
        [Key]
        [Column("VerksamhetsrollFKId", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerksamhetsrollId { get; set; }
        public virtual Systemanvandargrupp Systemanvandargrupp { get; set; }

        [Key]
        [Column("SystemanvandargruppFKId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SystemanvandargruppId { get; set; }
        public virtual Verksamhetsroll.Verksamhetsroll Verksamhetsroll { get; set; }
    }
}

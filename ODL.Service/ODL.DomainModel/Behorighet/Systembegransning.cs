using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ODL.DomainModel.Behorighet.Verksamhetsroll;

namespace ODL.DomainModel.Behorighet
{

    [Table("Behorighet.Systembegransning")]
    public partial class Systembegransning
    {
        [Key]
        [Column("PersonIVerksamhetsrollFKId", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonIVerksamhetsrollId { get; set; }
        public virtual PersonVerksamhetsroll PersonVerksamhetsroll { get; set; }
        

        [Key]
        [Column("SystemFKId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SystemId { get; set; }
        public virtual Systemroll.System System { get; set; }
    }
}

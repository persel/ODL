using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ODL.DomainModel.Behorighet.Verksamhetsroll;
using ODL.DomainModel.Behorighet.Verksamhetsdimension;

namespace ODL.DomainModel.Behorighet
{

    [Table("Behorighet.PersonIVerksamhetsrollVerksamhetsdimensionsvarde")]
    public partial class PersonIVerksamhetsrollVerksamhetsdimensionsvarde
    {
        [Key]
        [Column("PersonIVerksamhetsrollFKId", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonIVerksamhetsrollId { get; set; }
        public virtual PersonIVerksamhetsroll PersonIVerksamhetsroll { get; set; }

        [Key]
        [Column("VerksamhetsdimensionsvardeFKId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerksamhetsdimensionsvardeId { get; set; }
        public virtual Verksamhetsdimensionsvarde Verksamhetsdimensionsvarde { get; set; }
    }
}

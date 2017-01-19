using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ODL.DomainModel.Behorighet.Verksamhetsroll;
using ODL.DomainModel.Behorighet.Verksamhetsdimension;

namespace ODL.DomainModel.Behorighet
{

    [Table("Behorighet.PersonalVerksamhetsrollVerksamhetsdimensionsvarde")]
    public partial class PersonalIVerksamhetsrollVerksamhetsdimensionsvarde
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonalVerksamhetsrollFKId { get; set; }


        [Key]
        [Column("VerksamhetsdimensionsvardeFKId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerksamhetsdimensionsvardeId { get; set; }

        public virtual PersonalVerksamhetsroll PersonalVerksamhetsroll { get; set; }


    }
}

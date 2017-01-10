using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Behorighet.Systemattribut
{

    [Table("Behorighet.SystemattributVerksamhetsdimension")]
    public partial class VerksamhetsdimensionId : IdObjekt
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SystemattributFKId { get; private set; }

        //[Key]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int VerksamhetsdimensionFKId { get; private set; }

        public virtual Systemattribut Systemattribut { get; private set; }
    }
}

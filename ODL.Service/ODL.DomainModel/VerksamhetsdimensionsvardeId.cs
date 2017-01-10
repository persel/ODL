using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Behorighet.Systemattribut
{

    [Table("Behorighet.VerksamhetsdimensionsvardeSystemattributvarde")]
    public partial class VerksamhetsdimensionsvardeId : IdObjekt
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SystemattributvardeFKId { get; set; }

        //[Key]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int VerksamhetsdimensionvardeFKId { get; set; }

        public virtual Systemattributvarde Systemattributvarde { get; set; }
    }
}

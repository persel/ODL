using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet
{
    [Table("Behorighet.SystemattributVerksamhetsdimension")]
    public partial class SystemattributVerksamhetsdimension
    {
        [Key]
        [Column("SystemattributFKId", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SystemattributId { get; set; }
        public virtual Systemattribut.Systemattribut Systemattribut { get; set; }

        [Key]
        [Column("VerksamhetsdimensionFKId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerksamhetsdimensionId { get; set; }
        public virtual Verksamhetsdimension.Verksamhetsdimension Verksamhetsdimension { get; set; }
    }
}

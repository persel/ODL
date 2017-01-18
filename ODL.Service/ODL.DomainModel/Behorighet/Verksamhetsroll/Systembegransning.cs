using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Verksamhetsroll
{

    [Table("Behorighet.Systembegransning")]
    public partial class Systembegransning
    {
        [Key]
        [Column("PersonalVerksamhetsrollFKId", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonalVerksamhetsrollId { get; set; }

        [Key]
        [Column("SystemFKId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SystemId { get; set; }

        public virtual PersonalVerksamhetsroll PersonalVerksamhetsroll { get; set; }
    }
}

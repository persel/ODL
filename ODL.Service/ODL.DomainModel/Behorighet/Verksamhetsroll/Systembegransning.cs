using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Verksamhetsroll
{

    [Table("Behorighet.Systembegransning")]
    public partial class Systembegransning
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonVerksamhetsrollFKId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SystemFKId { get; set; }

        public virtual PersonVerksamhetsroll PersonVerksamhetsroll { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Verksamhetsroll
{
    
    [Table("Behorighet.Verksamhetsroll")]
    public partial class Verksamhetsroll
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Namn { get; set; }

    }
}

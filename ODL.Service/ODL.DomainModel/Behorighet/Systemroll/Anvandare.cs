using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Systemroll
{

    [Table("Behorighet.Anvandare")]
    public partial class Anvandare
    {
        public int Id { get; set; }

        [Column("PersonFKId")]
        public int PersonId { get; set; }

        [Required]
        [StringLength(10)]
        public string Alias { get; set; }
    }
}

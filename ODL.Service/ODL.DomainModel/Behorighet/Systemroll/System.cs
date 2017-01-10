using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Systemroll
{

    [Table("Behorighet.System")]
    public partial class System
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Namn { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ODL.DomainModel.Behorighet.Verksamhetsroll
{
    
    [Table("Behorighet.Verksamhetsroll")]
    public partial class Verksamhetsroll
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Namn { get; set; }

    }
}

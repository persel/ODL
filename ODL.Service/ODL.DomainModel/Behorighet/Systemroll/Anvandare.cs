using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ODL.DomainModel.Behorighet.Systemroll
{

    [Table("Behorighet.Anvandare")]
    public partial class Anvandare
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anvandare()
        {
            Systembehorighet = new HashSet<Systembehorighet>();
        }

        public int Id { get; set; }

        public int PersonFKId { get; set; }

        [Required]
        [StringLength(10)]
        public string Alias { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Systembehorighet> Systembehorighet { get; set; }
    }
}

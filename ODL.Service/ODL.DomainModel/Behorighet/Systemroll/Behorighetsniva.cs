using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ODL.DomainModel.Behorighet.Systemroll
{

    [Table("Behorighet.Behorighetsniva")]
    public partial class Behorighetsniva
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Behorighetsniva()
        {
            Systemanvandargrupp = new HashSet<Systemanvandargrupp>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SystemFKId { get; set; }

        [Required]
        [StringLength(50)]
        public string Namn { get; set; }

        public virtual System System { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Systemanvandargrupp> Systemanvandargrupp { get; set; }
    }
}

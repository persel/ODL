using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ODL.DomainModel.Behorighet.Systemroll
{

    [Table("Behorighet.Systemanvandargrupp")]
    public partial class Systemanvandargrupp
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Systemanvandargrupp()
        {
            Systembehorighet = new HashSet<Systembehorighet>();
        }

        public int Id { get; set; }

        [Column("SystemFKId")]
        public int SystemId { get; set; }

        [Column("BehorighetsnivaFKId")]
        public int BehorighetsnivaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Namn { get; set; }

        public virtual Behorighetsniva Behorighetsniva { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Systembehorighet> Systembehorighet { get; set; }
    }
}

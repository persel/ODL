using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ODL.DomainModel.Behorighet.Systemattribut
{

    [Table("Behorighet.Systemattribut")]
    public partial class Systemattribut
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Systemattribut()
        {
            Systemattributvarden = new HashSet<Systemattributvarde>();
            VerksamhetsdimensionIdn = new HashSet<VerksamhetsdimensionId>();
        }

        public int Id { get; set; }

        [Column("SystemFKId")]
        public int SystemId { get; set; }

        [Required]
        [StringLength(250)]
        public string Namn { get; set; }

        [Required]
        [StringLength(50)]
        public string Text { get; set; }
        
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Systemattributvarde> Systemattributvarden { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VerksamhetsdimensionId> VerksamhetsdimensionIdn { get; set; }
        

    }
}

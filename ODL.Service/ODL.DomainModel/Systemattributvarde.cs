using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using ODL.DomainModel.Behorighet.Systemattribut;

namespace ODL.DomainModel.Behorighet.Systemattribut
{


    [Table("Behorighet.Systemattributvarde")]
    public partial class Systemattributvarde
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Systemattributvarde()
        {
            Underliggande = new HashSet<Systemattributvarde>();
            SystembehorighetIdn = new HashSet<SystembehorighetId>();
            VerksamhetsdimensionvardeIdn = new HashSet<VerksamhetsdimensionId>();
        }

        public int Id { get; set; }

        public int SystemattributFKId { get; set; }

        public int? SystemattributvardeFKId { get; set; }

        public byte Datatyp { get; set; }

        [Required]
        [StringLength(250)]
        public string Varde { get; set; }

        public virtual Systemattribut Systemattribut { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Systemattributvarde> Underliggande { get; set; }

        public virtual Systemattributvarde Overordnad { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystembehorighetId> SystembehorighetIdn { get; set; }


        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VerksamhetsdimensionId> VerksamhetsdimensionvardeIdn { get; set; }
    }
}

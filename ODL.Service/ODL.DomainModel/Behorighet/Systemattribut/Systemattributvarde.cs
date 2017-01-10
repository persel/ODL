using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Behorighet.Systemattribut
{


    [Table("Behorighet.Systemattributvarde")]
    public partial class Systemattributvarde
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Systemattributvarde()
        {
            Underliggande = new HashSet<Systemattributvarde>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("SystemattributFKId")]
        public int SystemattributId { get; set; }

        [Column("SystemattributvardeFKId")]
        public int? SystemattributvardeId { get; set; }

        public Vardetyp Vardetyp { get; set; }

        [Required]
        [StringLength(250)]
        public string Varde { get; set; }

        public virtual Systemattribut Systemattribut { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Systemattributvarde> Underliggande { get; set; }

        public virtual Systemattributvarde Overordnad { get; set; }
        
    }
}

using ODL.DomainModel.Common;

namespace ODL.DomainModel.Behorighet.Verksamhetsdimension
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Behorighet.Verksamhetsdimensionsvarde")]
    public partial class Verksamhetsdimensionsvarde
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Verksamhetsdimensionsvarde()
        {
            Underliggande = new HashSet<Verksamhetsdimensionsvarde>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("VerksamhetsdimensionFKId")]
        public int VerksamhetsdimensionId { get; set; }

        [Column("VerksamhetsdimensionvardeFKId")]
        public int? VerksamhetsdimensionvardeId { get; set; } // Id för överordnat värde, om sådant finns

        public Vardetyp Vardetyp { get; set; }

        [Required]
        [StringLength(250)]
        public string Varde { get; set; }

        public virtual Verksamhetsdimension Verksamhetsdimension { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verksamhetsdimensionsvarde> Underliggande { get; set; }

        public virtual Verksamhetsdimensionsvarde Overordnad { get; set; }
    }
}

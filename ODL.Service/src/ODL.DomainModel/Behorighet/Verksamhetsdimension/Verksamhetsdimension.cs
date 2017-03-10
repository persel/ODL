using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Verksamhetsdimension
{

    [Table("Behorighet.Verksamhetsdimension")]
    public partial class Verksamhetsdimension
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Verksamhetsdimension()
        {
            Verksamhetsdimensionvarde = new HashSet<Verksamhetsdimensionsvarde>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Namn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verksamhetsdimensionsvarde> Verksamhetsdimensionvarde { get; set; }
    }
}

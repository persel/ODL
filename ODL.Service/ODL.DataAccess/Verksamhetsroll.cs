namespace ODL.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Behorighet.Verksamhetsroll")]
    public partial class Verksamhetsroll
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Verksamhetsroll()
        {
            PersonVerksamhetsroll = new HashSet<PersonVerksamhetsroll>();
            RelevantVerksamhetsdimension = new HashSet<RelevantVerksamhetsdimension>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Namn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonVerksamhetsroll> PersonVerksamhetsroll { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RelevantVerksamhetsdimension> RelevantVerksamhetsdimension { get; set; }
    }
}

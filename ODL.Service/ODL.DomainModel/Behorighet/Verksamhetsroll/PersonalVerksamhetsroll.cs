using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ODL.DomainModel.Behorighet.Verksamhetsroll
{

    [Table("Behorighet.PersonalVerksamhetsroll")]
    public partial class PersonalVerksamhetsroll
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonalVerksamhetsroll()
        {
            Systembegransning = new HashSet<Systembegransning>();
            PersonalIVerksamhetsrollVerksamhetsdimensionsvarde = new HashSet<PersonalIVerksamhetsrollVerksamhetsdimensionsvarde>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("VerksamhetsrollFKId")]
        public int VerksamhetsrollId { get; set; }

        [Column("PersonalFKId")]
        public int PersonalId { get; set; }

        public bool PrimarRoll { get; set; }

        public DateTime? TillfalligGallerFran { get; set; }

        public DateTime? TillfalligGallerTill { get; set; }

        public virtual Personal Personal { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Systembegransning> Systembegransning { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalIVerksamhetsrollVerksamhetsdimensionsvarde> PersonalIVerksamhetsrollVerksamhetsdimensionsvarde { get; set; }
    }
}

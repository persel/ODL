using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ODL.DomainModel.Behorighet.Verksamhetsroll
{

    [Table("Behorighet.PersonVerksamhetsroll")]
    public partial class PersonVerksamhetsroll
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonVerksamhetsroll()
        {
            Systembegransning = new HashSet<Systembegransning>();
            PersonIVerksamhetsrollVerksamhetsdimensionsvarde = new HashSet<PersonIVerksamhetsrollVerksamhetsdimensionsvarde>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int VerksamhetsrollFKId { get; set; }

        public int PersonFKId { get; set; }

        public bool PrimarRoll { get; set; }

        public DateTime? TillfalligGallerFran { get; set; }

        public DateTime? TillfalligGallerTill { get; set; }

        public virtual Person.Person Person { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Systembegransning> Systembegransning { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonIVerksamhetsrollVerksamhetsdimensionsvarde> PersonIVerksamhetsrollVerksamhetsdimensionsvarde { get; set; }
    }
}

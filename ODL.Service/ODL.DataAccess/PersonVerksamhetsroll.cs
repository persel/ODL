namespace ODL.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Behorighet.PersonVerksamhetsroll")]
    public partial class PersonVerksamhetsroll
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonVerksamhetsroll()
        {
            PersonVerksamhetsrollVerksamhetsdimensionvarde = new HashSet<PersonVerksamhetsrollVerksamhetsdimensionvarde>();
            Systembegransning = new HashSet<Systembegransning>();
        }

        public int Id { get; set; }

        public int VerksamhetsrollFKId { get; set; }

        public int PersonFKId { get; set; }

        public bool TillfalligRoll { get; set; }

        public bool PrimarRoll { get; set; }

        public DateTime? GallerFran { get; set; }

        public DateTime? GallerTill { get; set; }

        public virtual Person Person { get; set; }

        public virtual Verksamhetsroll Verksamhetsroll { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonVerksamhetsrollVerksamhetsdimensionvarde> PersonVerksamhetsrollVerksamhetsdimensionvarde { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Systembegransning> Systembegransning { get; set; }
    }
}

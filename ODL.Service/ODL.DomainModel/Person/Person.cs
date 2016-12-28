using System.Collections.Generic;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Person
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Person.Person")]
    public partial class Person
    {
        public Person()
        {
            PersonVerksamhetsroll = new HashSet<PersonVerksamhetsroll>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string KallsystemId { get; set; }

        [Required]
        [StringLength(255)]
        public string Fornamn { get; set; }

        [StringLength(255)]
        public string Mellannamn { get; set; }

        [Required]
        [StringLength(255)]
        public string Efternamn { get; set; }

        [Required]
        [StringLength(12)]
        public string Personnummer { get; set; }

        public Metadata Metadata { get; set; }
        
        public virtual Anstalld Anstalld { get; set; }

        public virtual Konsult Konsult { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonVerksamhetsroll> PersonVerksamhetsroll { get; set; }
    }
}

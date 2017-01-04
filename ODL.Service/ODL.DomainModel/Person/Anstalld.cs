namespace ODL.DomainModel.Person
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("Person.Anstalld")]
    public partial class Anstalld
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anstalld()
        {
            AnstallningsAvtal = new HashSet<AnstallningsAvtal>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonFKId { get; set; }

        public Metadata Metadata { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnstallningsAvtal> AnstallningsAvtal { get; set; }

        [NotMapped]
        public IEnumerable<int> AnstallningsAvtalIdn => AnstallningsAvtal.Select(anstallningsAvtal => anstallningsAvtal.AvtalFKId);
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Person
{

    [Table("Person.Person")]
    public partial class Person
    {

        public Person()
        {
            AnstallningsAvtal = new HashSet<AnstallningsAvtal>();
            KonsultAvtal = new HashSet<KonsultAvtal>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnstallningsAvtal> AnstallningsAvtal { get; set; }

        [NotMapped]
        public IEnumerable<int> AnstallningsAvtalIdn => AnstallningsAvtal.Select(anstallningsAvtal => anstallningsAvtal.AvtalFKId);

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KonsultAvtal> KonsultAvtal { get; set; }

        [NotMapped]
        public IEnumerable<int> KonsultAvtalIdn => KonsultAvtal.Select(konsultAvtal => konsultAvtal.AvtalFKId);

    }
}

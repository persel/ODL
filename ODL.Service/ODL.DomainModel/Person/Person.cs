using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Person
{

    [Table("Person.Person")]
    public partial class Person
    {
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
        
        public virtual Anstalld Anstalld { get; set; }

        public virtual Konsult Konsult { get; set; }
        
    }
}

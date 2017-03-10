using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Person
{

    [Table("Person.AnstalldAvtal")]
    public partial class AnstalldAvtal
    {

        public int PersonFKId { get; set; }

        public virtual Person Anstalld { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AvtalFKId { get; set; }

        public virtual Avtal Avtal { get; set; }

    }
}

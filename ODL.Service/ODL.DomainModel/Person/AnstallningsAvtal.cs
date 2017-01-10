using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Person
{

    [Table("Person.AnstalldAvtal")]
    public partial class AnstallningsAvtal
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonFKId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AvtalFKId { get; set; }

        public virtual Anstalld Anstalld { get; set; }

    }
}

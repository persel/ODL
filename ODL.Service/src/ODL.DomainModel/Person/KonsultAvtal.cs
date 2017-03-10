using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Person
{

    [Table("Person.KonsultAvtal")]
    public partial class KonsultAvtal
    {

        public int PersonFKId { get; set; }

        public virtual Person Konsult { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AvtalFKId { get; set; }

        public virtual Avtal Avtal { get; set; }
    }
}

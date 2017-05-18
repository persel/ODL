using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Organisation
{

    [Table("Person.OrganisationAvtal")]
    public class OrganisationAvtal
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AvtalId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganisationId { get; set; }

        public decimal? ProcentuellFordelning { get; set; }

        public bool HuvudsakligtKostnadsstalle { get; set; } // Kallas Huvudkostnadsställe i HR-plus, men för att särskilja mot ResultatenhetTyp 'H', kallar vi denna egenskap för HuvudsakligtKostnadsstalle

        public virtual Avtal.Avtal Avtal { get; set; }
        
        public bool Ny => AvtalId == 0;
    }
}

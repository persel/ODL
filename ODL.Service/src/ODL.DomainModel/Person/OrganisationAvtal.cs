using ODL.DomainModel.Person;

namespace ODL.DomainModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Person.OrganisationAvtal")]
    public partial class OrganisationAvtal
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

        public bool Huvudkostnadsstalle { get; set; }

        public virtual Avtal Avtal { get; set; }
        
        public virtual Organisation.Organisation Organisation { get; set; }
        public bool IsNew => AvtalId == 0;
    }
}

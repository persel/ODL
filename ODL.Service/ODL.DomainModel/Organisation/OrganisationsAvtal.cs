namespace ODL.DomainModel.Organisation
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Person.OrganisationAvtal")]
    public partial class OrganisationsAvtal
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AvtalFKId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganisationFKId { get; set; }

        public virtual Organisation Organisation { get; set; }
    }
}

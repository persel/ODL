namespace ODL.DomainModel.Adress
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Adress.OrganisationAdress")]
    public partial class OrganisationAdress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdressFKId { get; set; }

        public int OrganisationFKId { get; set; }

        public virtual Adress Adress { get; set; }
    }
}

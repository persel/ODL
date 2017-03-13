namespace ODL.DomainModel.Adress
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Adress.Telefon")]
    public partial class Telefon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdressFKId { get; set; }

        [Required]
        [StringLength(25)]
        public string Telefonnummer { get; set; }
       

        public virtual Adress Adress { get; set; }
    }
}

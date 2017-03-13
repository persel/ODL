namespace ODL.DomainModel.Adress
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Adress.GatuAdress")]
    public partial class GatuAdress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdressFKId { get; set; }

        [StringLength(255)]
        public string AdressRad1 { get; set; }

        [StringLength(255)]
        public string AdressRad2 { get; set; }

        [StringLength(255)]
        public string AdressRad3 { get; set; }

        [StringLength(255)]
        public string AdressRad4 { get; set; }

        [StringLength(255)]
        public string AdressRad5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Postnummer { get; set; }

        [Required]
        [StringLength(255)]
        public string Stad { get; set; }

        [StringLength(255)]
        public string Land { get; set; }


        public virtual Adress Adress { get; set; }
    }
}

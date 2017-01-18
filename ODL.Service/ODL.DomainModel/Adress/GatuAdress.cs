namespace ODL.DomainModel.Adress
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

        public DateTime? UppdateradDatum { get; set; }

        [StringLength(10)]
        public string UppdateradAv { get; set; }

        public DateTime SkapadDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string SkapadAv { get; set; }

        public virtual Adress Adress { get; set; }
    }
}

namespace ODL.DomainModel.Adress
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Adress.AdressVariant")]
    public partial class AdressVariant
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public AdressVariant()
        //{
        //    Adress = new HashSet<Adress>();
        //}

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Namn { get; set; }

        public DateTime? UppdateradDatum { get; set; }

        [StringLength(10)]
        public string UppdateradAv { get; set; }

        public DateTime SkapadDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string SkapadAv { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Adress> Adress { get; set; }

        [Column("AdressTypFKId")]
        public  AdressTyp AdressTyp { get; set; } // Detta är en tabell i databasen, för att vi ska få referensintegritet och "läsbarhet" i db
    }
}

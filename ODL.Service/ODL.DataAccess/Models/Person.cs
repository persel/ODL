namespace ODL.DataAccess.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Person.Person")]
    public partial class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("Fornamn")]
        public string Förnamn { get; set; }

        [StringLength(255)]
        public string Mellannamn { get; set; }

        [Required]
        [StringLength(255)]
        public string Efternamn { get; set; }

        [Required]
        [StringLength(12)]
        public string Personnummer { get; set; }

        public DateTime UppdateradDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string UppdateradAv { get; set; }

        public DateTime SkapadDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string SkapadAv { get; set; }

        public virtual Anställd Anställd { get; set; }

        public virtual Konsult Konsult { get; set; }
    }
}

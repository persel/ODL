namespace ODL.DataAccess.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Person.Anstalld")]
    public partial class Anställd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonFKId { get; set; }

        public byte? Typ { get; set; }

        [Required]
        [StringLength(10)]
        public string Alias { get; set; }

        public DateTime UppdateradDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string UppdateradAv { get; set; }

        public DateTime SkapadDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string SkapadAv { get; set; }

        public virtual Person Person { get; set; }
    }
}

namespace ODL.DomainModel.Adress
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

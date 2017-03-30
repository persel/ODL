using System.Collections.Generic;

namespace ODL.DomainModel.Adress
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Adress.AdressVariant")]
    public partial class AdressVariant
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Namn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adress> Adress { get; set; }

        [Column("AdressTypFKId")]
        public  AdressTyp AdressTyp { get; set; } // Detta är en tabell i databasen, för att vi ska få referensintegritet och "läsbarhet" i db
    }
}

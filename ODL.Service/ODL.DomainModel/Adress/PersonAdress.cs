namespace ODL.DomainModel.Adress
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adress.PersonAdress")]
    public partial class PersonAdress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdressFKId { get; set; }

        public int PersonFKId { get; set; }

        public virtual Adress Adress { get; set; }
    }
}

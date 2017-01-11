using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Verksamhetsroll
{

    [Table("Behorighet.PersonVerksamhetsroll")]
    public partial class PersonVerksamhetsroll
    {
        public int Id { get; set; }

        [Column("VerksamhetsrollFKId")]
        public int VerksamhetsrollId { get; set; }

        public Person.Person Person { get; set; }

        [Column("PersonFKId")]
        public int PersonId { get; set; }

        public bool PrimarRoll { get; set; }

        public DateTime? TillfalligGallerFran { get; set; }

        public DateTime? TillfalligGallerTill { get; set; }
        
    }
}

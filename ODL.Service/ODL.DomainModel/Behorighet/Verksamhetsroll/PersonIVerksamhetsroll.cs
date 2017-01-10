using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Verksamhetsroll
{

    [Table("Behorighet.PersonIVerksamhetsroll")]
    public partial class PersonIVerksamhetsroll
    {
        public int Id { get; set; }

        [Column("VerksamhetsrollFKId")]
        public int VerksamhetsrollId { get; set; }

        [Column("PersonFKId")]
        public int PersonId { get; set; }

        public bool PrimarRoll { get; set; }

        public DateTime? TillfalligGallerFran { get; set; }

        public DateTime? TillfalligGallerTill { get; set; }

        public virtual Verksamhetsroll Verksamhetsroll { get; set; }
    }
}

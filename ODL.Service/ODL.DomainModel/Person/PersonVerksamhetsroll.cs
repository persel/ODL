using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Behorighet.Verksamhetsroll
{

    [Table("Behorighet.PersonVerksamhetsroll")]
    public partial class PersonVerksamhetsroll
    {
        public int Id { get; set; }

        public int VerksamhetsrollFKId { get; set; }

        public int PersonFKId { get; set; }

        public bool PrimarRoll { get; set; }

        public DateTime? TillfalligGallerFran { get; set; }

        public DateTime? TillfalligGallerTill { get; set; }

        public virtual Person.Person Person { get; set; }
    }
}

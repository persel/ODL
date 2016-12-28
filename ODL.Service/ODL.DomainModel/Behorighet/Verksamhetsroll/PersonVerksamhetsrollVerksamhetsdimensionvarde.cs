namespace ODL.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Behorighet.PersonVerksamhetsrollVerksamhetsdimensionvarde")]
    public partial class PersonVerksamhetsrollVerksamhetsdimensionvarde
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonVerksamhetsrollFKId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerksamhetsdimensionvardeFKId { get; set; }

        public virtual PersonVerksamhetsroll PersonVerksamhetsroll { get; set; }
    }
}

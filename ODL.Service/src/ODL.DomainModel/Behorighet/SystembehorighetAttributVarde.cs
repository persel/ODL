using ODL.DomainModel.Behorighet.Systemattribut;
using ODL.DomainModel.Behorighet.Systemroll;

namespace ODL.DomainModel.Behorighet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Behorighet.SystembehorighetAttributVarde")]
    public partial class SystembehorighetAttributVarde
    {
        [Key]
        [Column("SystemattributvardeFKId", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SystemattributvardeFKId { get; set; }
        public virtual Systemattributvarde Systemattributvarde { get; set; }

        [Key]
        [Column("SystembehorighetFKId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SystembehorighetId { get; set; }
        public virtual Systembehorighet Systembehorighet { get; set; }
    }
}

namespace ODL.DomainModel.Behorighet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Behorighet.RelevantVerksamhetsdimension")]
    public partial class RelevantVerksamhetsdimension
    {
        [Key]
        [Column("VerksamhetsrollFKId", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerksamhetsrollId { get; set; }
        public virtual Verksamhetsroll.Verksamhetsroll Verksamhetsroll { get; set; }

        [Key]
        [Column("VerksamhetsdimensionFKId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerksamhetsdimensionId { get; set; }
        public virtual Verksamhetsdimension.Verksamhetsdimension Verksamhetsdimension { get; set; }
    }
}

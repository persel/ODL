namespace ODL.DataAccess
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
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerksamhetsrollFKId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerksamhetsdimensionFKId { get; set; }

        public virtual Verksamhetsroll Verksamhetsroll { get; set; }
    }
}

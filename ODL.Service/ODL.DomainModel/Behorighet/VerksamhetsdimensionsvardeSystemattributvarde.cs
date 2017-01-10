using ODL.DomainModel.Behorighet.Systemattribut;
using ODL.DomainModel.Behorighet.Verksamhetsdimension;

namespace ODL.DomainModel.Behorighet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Behorighet.VerksamhetsdimensionsvardeSystemattributvarde")]
    public partial class VerksamhetsdimensionsvardeSystemattributvarde
    {
        [Key]
        [Column("SystemattributvardeFKId", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SystemattributvardeId { get; set; }
        public virtual Systemattributvarde Systemattributvarde { get; set; }

        [Key]
        [Column("VerksamhetsdimensionvardeFKId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerksamhetsdimensionvardeId { get; set; }
        public virtual Verksamhetsdimensionsvarde Verksamhetsdimensionsvarde { get; set; }
    }
}

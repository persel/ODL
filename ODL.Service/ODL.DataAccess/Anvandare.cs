namespace ODL.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Behorighet.Anvandare")]
    public partial class Anvandare
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonFKId { get; set; }

        [Required]
        [StringLength(50)]
        public string Alias { get; set; }

        public virtual Person Person { get; set; }
    }
}

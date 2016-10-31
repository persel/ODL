using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PTJ.DataLayer.Models
{
    [Table("AvtalResultatEnhet", Schema = "Person")]
    public partial class AvtalResultatEnhet
    {
        [Key]
        public long Id { get; set; }

        public long AvtalFKID { get; set; }

        public long ResultatEnhetFKID { get; set; }
 
    }
}

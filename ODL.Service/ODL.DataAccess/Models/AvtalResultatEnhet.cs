using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ODL.DataAccess.Models
{
    [Table("AvtalResultatEnhet", Schema = "Person")]
    public partial class AvtalResultatEnhet
    {
        [Key]
        public int Id { get; set; }

        public int AvtalFKID { get; set; }

        public int ResultatEnhetFKID { get; set; }
 
    }
}

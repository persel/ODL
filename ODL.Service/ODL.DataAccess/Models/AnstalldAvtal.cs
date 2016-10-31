using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ODL.DataAccess.Models
{
    [Table("AnstalldAvtal", Schema = "Person")]
    public partial class AnstalldAvtal
    {
        [Key]
        public int Id { get; set; }
        public int AnstalldFkid { get; set; }

        public int AvtalFkid { get; set; }
    }
}

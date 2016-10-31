using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PTJ.DataLayer.Models
{
    [Table("AnstalldAvtal", Schema = "Person")]
    public partial class AnstalldAvtal
    {
        [Key]
        public long Id { get; set; }
        public long AnstalldFkid { get; set; }

        public long AvtalFkid { get; set; }
    }
}

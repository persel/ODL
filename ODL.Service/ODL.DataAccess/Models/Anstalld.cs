using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ODL.DataAccess.Models
{
    [Table("Anstalld", Schema = "Person")]
    public partial class Anstalld
    {
        [Key]
        public int Id { get; set; }

        public byte Typ { get; set; }
  
        public string Alias { get; set; }

        public string UppdateradAv { get; set; }

        public DateTime SkapadDatum { get; set; }

        public DateTime? UppdateradDatum { get; set; }
       
    }
}

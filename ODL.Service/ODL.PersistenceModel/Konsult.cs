using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PTJ.DataLayer.Models
{
    [Table("Konsult", Schema = "Person")]
    public partial class Konsult
    {
        [Key]
        public long Id { get; set; }

        public string Alias { get; set; }

        public string UppdateradAv { get; set; }

        public DateTime SkapadDatum { get; set; }

        public DateTime? UppdateradDatum { get; set; }
       
    }
}

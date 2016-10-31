using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ODL.DataAccess.Models
{
    [Table("Konsult", Schema = "Person")]
    public partial class Konsult
    {
        [Key]
        public int Id { get; set; }

        public string Alias { get; set; }

        public string UppdateradAv { get; set; }

        public DateTime SkapadDatum { get; set; }

        public DateTime? UppdateradDatum { get; set; }
       
    }
}

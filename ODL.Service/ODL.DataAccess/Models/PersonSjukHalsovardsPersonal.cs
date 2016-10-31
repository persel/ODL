using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ODL.DataAccess.Models
{
    [Table("PersonSjukHalsovardsPersonal", Schema = "Person")]
    public partial class PersonSjukHalsovardsPersonal
    {
        [Key]
        public int Id { get; set; }
        public int PersonFkid { get; set; }
        public int SjukHalsovardsPersonalFkid { get; set; }
        public string UpdateradAv { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }

        //public virtual Person PersonFk { get; set; }
    }
}

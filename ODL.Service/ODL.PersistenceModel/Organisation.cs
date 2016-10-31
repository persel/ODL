using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTJ.DataLayer.Models
{
    [Table("Organisation", Schema = "Organisation")]
    public partial class Organisation
    {
       
        [Key]
        public long Id { get; set; }
        public string OrganisationsId { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpDateradDatum { get; set; }
        public string UpdateradAv { get; set; }
        public long? IngarIorganisation { get; set; }

        public string Namn { get; set; }

    }
}

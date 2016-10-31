using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DataAccess.Models
{
    [Table("Organisation", Schema = "Organisation")]
    public partial class Organisation
    {
       
        [Key]
        public int Id { get; set; }
        public string OrganisationsId { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpDateradDatum { get; set; }
        public string UpdateradAv { get; set; }
        public long? IngarIorganisation { get; set; }

        public string Namn { get; set; }

    }
}

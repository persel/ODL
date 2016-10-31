using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTJ.DataLayer.Models
{
    [Table("ResultatEnhet", Schema = "Organisation")]
    public partial class ResultatEnhet
    {
       
        [Key]
        public long Id { get; set; }

        public int Kstnr { get; set; }

        public string Typ { get; set; }

        public long EnhetFKID { get; set; }

        public long OrganisationFKID { get; set; }


    }
}

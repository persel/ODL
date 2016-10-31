using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DataAccess.Models
{
    [Table("ResultatEnhet", Schema = "Organisation")]
    public partial class ResultatEnhet
    {
       
        [Key]
        public int Id { get; set; }

        public int Kstnr { get; set; }

        public string Typ { get; set; }

        public int EnhetFKID { get; set; }

        public int OrganisationFKID { get; set; }


    }
}

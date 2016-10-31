using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ODL.PersistenceModel;

namespace ODL.DataAccess.Models
{
    [Table("OrganisationAdress", Schema = "Adress")]
    public partial class OrganisationAdress
    {
        [Key]
        public int Id { get; set; }
        
        public int OrganisationFkid { get; set; }

     
        public int AdressFkid { get; set; }
        public string UpdateradAv { get; set; }
        public DateTime? SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }

        public virtual Adress AdressFk { get; set; }
        public virtual Organisation OrganisationFk { get; set; }
    }
}

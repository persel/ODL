using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ODL.DataAccess.Models
{
    [Table("PersonAdress", Schema = "Adress")]
    public partial class PersonAdress
    {
        [Key]
        public int Id { get; set; }
        public int PersonFkid { get; set; }
        public int AdressFkid { get; set; }
        public string UpdateradAv { get; set; }
        public DateTime? SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }

        //public virtual Adress AdressFk { get; set; }
        //public virtual Person PersonFk { get; set; }
    }
}

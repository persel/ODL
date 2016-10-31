using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTJ.DataLayer.Models
{
    [Table("AdressTyp", Schema = "Adress")]
    public partial class AdressTyp
    {
        //public AdressTyp()
        //{
        //    Adress = new HashSet<Adress>();
        //    AdressVariant = new HashSet<AdressVariant>();
        //}
        [Key]
        public long Id { get; set; }
        public string Typ { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }
        public string UpdateradAv { get; set; }

        //public virtual ICollection<Adress> Adress { get; set; }
        //public virtual ICollection<AdressVariant> AdressVariant { get; set; }
    }
}

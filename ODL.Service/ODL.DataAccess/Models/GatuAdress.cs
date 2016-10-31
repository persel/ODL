using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DataAccess.Models
{
    [Table("GatuAdress", Schema = "Adress")]
    public partial class GatuAdress
    {
        [Key]
        public int Id { get; set; }
        public int AdressFkid { get; set; }
        public string AdressRad1 { get; set; }
        public string AdressRad2 { get; set; }
        public string AdressRad3 { get; set; }
        public string AdressRad4 { get; set; }
        public string AdressRad5 { get; set; }
        public decimal Postnummer { get; set; }
        public string Stad { get; set; }
        public string Land { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }
        public string UpdateradAv { get; set; }

        //public virtual Adress AdressFk { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PTJ.DataLayer.Models
{
    [Table("Avtal", Schema = "Person")]
    public partial class Avtal
    {
        [Key]
        public long Id { get; set; }

        public string AvtalsKod { get; set; }

        public string AvtalsText { get; set; }

        public int? Befkod { get; set; }

        public string Beftext { get; set; }

        public string Aktiv { get; set; }

        public string Ansvarig { get; set; }

        public string Chef { get; set; }

        public DateTime TjledigFran { get; set; }

        public DateTime TjledigTom { get; set; }

        public float Fproc { get; set; }

        public string DeltidFranvaro { get; set; }

        public string FranvaroProcent { get; set; }

        public string SjukP { get; set; }

        public float GrundArbtidVecka { get; set; }

        public float Lon { get; set; }

        public DateTime LonDatum { get; set; }

        public string LoneTyp { get; set; }

        public long LoneTillagg { get; set; }

        public long TimLon { get; set; }

        public string UppdateradAv { get; set; }

        public DateTime UppdateradDatum { get; set; }

        public DateTime AnstallningsDatum { get; set; }

        public DateTime AvgangsDatum { get; set; }

        public DateTime SkapadDatum { get; set; }

    }
}

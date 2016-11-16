namespace ODL.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person.Avtal")]
    public partial class Avtal
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Avtalskod { get; set; }

        [StringLength(50)]
        public string Avtalstext { get; set; }

        public int? ArbetstidVecka { get; set; }

        public int? Befkod { get; set; }

        [StringLength(50)]
        public string BefText { get; set; }

        public bool? Aktiv { get; set; }

        public bool? Ansvarig { get; set; }

        public bool? Chef { get; set; }

        public DateTime? TjledigFran { get; set; }

        public DateTime? TjledigTom { get; set; }

        public double? Fproc { get; set; }

        [StringLength(10)]
        public string DeltidFranvaro { get; set; }

        public double? FranvaroProcent { get; set; }

        [StringLength(10)]
        public string SjukP { get; set; }

        public double? GrundArbtidVecka { get; set; }

        public int? Lon { get; set; }

        public DateTime? LonDatum { get; set; }

        [StringLength(10)]
        public string LoneTyp { get; set; }

        public int? LoneTillagg { get; set; }

        public int? TimLon { get; set; }

        public DateTime? Anstallningsdatum { get; set; }

        public DateTime? Avgangsdatum { get; set; }

        public DateTime UppdateradDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string UppdateradAv { get; set; }

        public DateTime SkapadDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string SkapadAv { get; set; }
    }
}

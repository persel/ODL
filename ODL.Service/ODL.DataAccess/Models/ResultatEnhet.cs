namespace ODL.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Organisation.Resultatenhet")]
    public partial class Resultatenhet
    {
        public int Id { get; set; }

        public int Kstnr { get; set; }

        [StringLength(100)]
        public string Namn { get; set; }

        [StringLength(10)]
        public string Typ { get; set; }

        public int? OrganisationFKId { get; set; }

        public DateTime? UppdateradDatum { get; set; }

        [StringLength(100)]
        public string UppdateradAv { get; set; }

        public DateTime SkapadDatum { get; set; }

        [StringLength(100)]
        public string SkapadAv { get; set; }

        public virtual Organisation Organisation { get; set; }
    }
}

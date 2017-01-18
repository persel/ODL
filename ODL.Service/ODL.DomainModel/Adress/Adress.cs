namespace ODL.DomainModel.Adress
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adress.Adress")]
    public partial class Adress
    {
        public int Id { get; set; }

        public int AdressVariantFKId { get; set; }

        public DateTime? UppdateradDatum { get; set; }

        [StringLength(10)]
        public string UppdateradAv { get; set; }

        public DateTime SkapadDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string SkapadAv { get; set; }

        //public virtual AdressVariant AdressVariant { get; set; }

        public virtual GatuAdress GatuAdress { get; set; }

        public virtual Mail Mail { get; set; }

        public virtual OrganisationAdress OrganisationAdress { get; set; }

        public virtual PersonAdress PersonAdress { get; set; }

        public virtual Telefon Telefon { get; set; }
    }
}

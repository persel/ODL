using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.PersistenceModel
{
    [Table("Adress", Schema = "Adress")]
    public class Adress
    {
        //public Adress()
        //{
        //    //GatuAdress = new HashSet<GatuAdress>();
        //    //Mail = new HashSet<Mail>();
        //    //OrganisationAdress = new HashSet<OrganisationAdress>();
        //    //PersonAdress = new HashSet<PersonAdress>();
        //    //Telefon = new HashSet<Telefon>();
        //}

        [Key]
        public int Id { get; set; }

        //[Column("AdressTypFkid")]
        //[ForeignKey("AdressTyp.Id")]
        public int AdressTypFkid { get; set; }

        //[Column("AdressVariantFkid")]
        //[ForeignKey(" AdressVariant.Id")]
        public int AdressVariantFkid { get; set; }

        public DateTime SkapadDatum { get; set; }

        public DateTime? UpdateradDatum { get; set; }

        public string UpdateradAv { get; set; }

        //public virtual ICollection<GatuAdress> GatuAdress { get; set; }
        //public virtual ICollection<Mail> Mail { get; set; }
        ////public virtual ICollection<OrganisationAdress> OrganisationAdress { get; set; }
        //public virtual ICollection<PersonAdress> PersonAdress { get; set; }
        ////public virtual ICollection<Telefon> Telefon { get; set; }
        //public virtual AdressTyp AdressTypFk { get; set; }
        //public virtual AdressVariant AdressVariantFk { get; set; }
    }
}

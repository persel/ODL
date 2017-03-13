using ODL.DomainModel.Common;

namespace ODL.DomainModel.Adress
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Adress.Adress")]
    public partial class Adress
    {
        public int Id { get; set; }

        public int AdressVariantFKId { get; set; }

        public Metadata Metadata { get; set; }

        //public virtual AdressVariant AdressVariant { get; set; }

        public virtual GatuAdress GatuAdress { get; set; }

        public virtual Mail Mail { get; set; }

        public virtual Telefon Telefon { get; set; }

        public virtual OrganisationAdress OrganisationAdress { get; set; }

        public virtual PersonAdress PersonAdress { get; set; }

        

        [NotMapped]
        public bool IsNew => Id == 0;

        public static Adress NewGatuAdress(Person.Person person)
        {
            var adress = new Adress { GatuAdress = new GatuAdress() };
            adress.PersonAdress = new PersonAdress { PersonFKId = person.Id };
            return adress;
        }

        public static Adress NewEpostAdress(Person.Person person)
        {
            var adress = new Adress{Mail = new Mail()};
            adress.PersonAdress = new PersonAdress { PersonFKId = person.Id };
            return adress;
        }

        public static Adress NewTelefonAdress(Person.Person person)
        {
            var adress = new Adress { Telefon = new Telefon() };
            adress.PersonAdress = new PersonAdress { PersonFKId = person.Id };
            return adress;
        }

        public static Adress NewGatuAdress(Organisation.Organisation organisation)
        {
            var adress = new Adress { GatuAdress = new GatuAdress() };
            adress.OrganisationAdress = new OrganisationAdress { OrganisationFKId = organisation.Id };
            return adress;
        }

        public static Adress NewEpostAdress(Organisation.Organisation organisation)
        {
            var adress = new Adress { Mail = new Mail() };
            adress.OrganisationAdress = new OrganisationAdress { OrganisationFKId = organisation.Id };
            return adress;
        }

        public static Adress NewTelefonAdress(Organisation.Organisation organisation)
        {
            var adress = new Adress { Telefon = new Telefon() };
            adress.OrganisationAdress = new OrganisationAdress { OrganisationFKId = organisation.Id };
            return adress;
        }

        public void SetVariant(AdressVariant variant)
        {
            AdressVariantFKId = variant.Id;
        }
    }
}

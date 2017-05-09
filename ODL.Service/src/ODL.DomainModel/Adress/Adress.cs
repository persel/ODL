using ODL.DomainModel.Common;

namespace ODL.DomainModel.Adress
{
    public class Adress
    {
        public int Id { get; set; }


        public Metadata Metadata { get; set; }
        
        public virtual AdressVariant AdressVariant { get; set; }

        public virtual Gatuadress Gatuadress { get; set; }

        public virtual Mail Mail { get; set; }

        public virtual Telefon Telefon { get; set; }

        public virtual OrganisationAdress OrganisationAdress { get; set; }

        public virtual PersonAdress PersonAdress { get; set; }

        public bool IsNew => Id == 0;

        public static Adress NyGatuadress(Person.Person person)
        {
            var adress = new Adress { Gatuadress = new Gatuadress() };
            adress.PersonAdress = new PersonAdress { PersonId = person.Id };
            return adress;
        }

        public static Adress NyEpostAdress(Person.Person person)
        {
            var adress = new Adress{Mail = new Mail()};
            adress.PersonAdress = new PersonAdress { PersonId = person.Id };
            return adress;
        }

        public static Adress NyTelefonAdress(Person.Person person)
        {
            var adress = new Adress { Telefon = new Telefon() };
            adress.PersonAdress = new PersonAdress { PersonId = person.Id };
            return adress;
        }

        public static Adress NyGatuadress(Organisation.Organisation organisation)
        {
            var adress = new Adress { Gatuadress = new Gatuadress() };
            adress.OrganisationAdress = new OrganisationAdress { OrganisationId = organisation.Id };
            return adress;
        }

        public static Adress NyEpostAdress(Organisation.Organisation organisation)
        {
            var adress = new Adress { Mail = new Mail() };
            adress.OrganisationAdress = new OrganisationAdress { OrganisationId = organisation.Id };
            return adress;
        }

        public static Adress NyTelefonAdress(Organisation.Organisation organisation)
        {
            var adress = new Adress { Telefon = new Telefon() };
            adress.OrganisationAdress = new OrganisationAdress { OrganisationId = organisation.Id };
            return adress;
        }

        public void SetVariant(AdressVariant variant)
        {
            AdressVariant = variant;
        }
    }
}

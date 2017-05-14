using ODL.DomainModel.Common;

namespace ODL.DomainModel.Adress
{
    public class Adress
    {
        public int Id { get; set; }

        public Metadata Metadata { get; set; }
        
        public virtual Adressvariant Adressvariant { get; set; }

        public virtual Gatuadress Gatuadress { get; private set; }

        public virtual Mail Mail { get; set; }

        public virtual Telefon Telefon { get; set; }

        public virtual OrganisationAdress OrganisationAdress { get; set; }

        public virtual PersonAdress PersonAdress { get; set; }

        public bool Ny => Id == 0;

        public static Adress SkapaNyGatuadress(string adressRad1, string postnummer, string stad, string land, Adressvariant variant, Metadata metadata, Person.Person person)
        {
            VerifieraAdressTyp(variant, Adresstyp.Gatuadress);
            
            var gatuadress = new Gatuadress(adressRad1, postnummer, stad, land);
            var adress = new Adress
            {
                Gatuadress = gatuadress,
                PersonAdress = new PersonAdress {PersonId = person.Id},
                Metadata = metadata
                
            };
            return adress;
        }
        
        public static Adress SkapaNyEpostAdress(string mailAdress, Adressvariant variant, Metadata metadata, Person.Person person)
        {
            VerifieraAdressTyp(variant, Adresstyp.EpostAdress);

            var mail = new Mail(mailAdress);
            var adress = new Adress
            {
                Mail = mail,
                PersonAdress = new PersonAdress { PersonId = person.Id },
                Metadata = metadata
            };
            
            return adress;
        }

        public static Adress SkapaNyTelefonAdress(string telefonnummer, Adressvariant variant, Metadata metadata, Person.Person person)
        {
            VerifieraAdressTyp(variant, Adresstyp.Telefon);

            var telefon = new Telefon(telefonnummer);
            var adress = new Adress
            {
                Telefon = telefon,
                PersonAdress = new PersonAdress { PersonId = person.Id },
                Metadata = metadata
            };

            return adress;
        }

        public static Adress SkapaNyGatuadress(string adressRad1, string postnummer, string stad, string land, Adressvariant variant, Metadata metadata, Organisation.Organisation organisation)
        {
            VerifieraAdressTyp(variant, Adresstyp.Gatuadress);

            var gatuadress = new Gatuadress(adressRad1, postnummer, stad, land);
            var adress = new Adress
            {
                Gatuadress = gatuadress,
                OrganisationAdress = new OrganisationAdress { OrganisationId = organisation.Id },
                Metadata = metadata
            };
            return adress;
        }

        public static Adress SkapaNyEpostAdress(string mailAdress, Adressvariant variant, Metadata metadata, Organisation.Organisation organisation)
        {
            VerifieraAdressTyp(variant, Adresstyp.EpostAdress);

            var mail = new Mail(mailAdress);
            var adress = new Adress
            {
                Mail = mail,
                OrganisationAdress = new OrganisationAdress { OrganisationId = organisation.Id },
                Metadata = metadata
            };

            return adress;
        }

        public static Adress SkapaNyTelefonAdress(string telefonnummer, Adressvariant variant, Metadata metadata, Organisation.Organisation organisation)
        {
            VerifieraAdressTyp(variant, Adresstyp.Telefon);

            var telefon = new Telefon(telefonnummer);
            var adress = new Adress
            {
                Telefon = telefon,
                OrganisationAdress = new OrganisationAdress{ OrganisationId = organisation.Id },
                Metadata = metadata
            };

            return adress;
        }

        private static void VerifieraAdressTyp(Adressvariant variant, Adresstyp adresstyp)
        {
            if (variant.Adresstyp() != adresstyp)
                throw new BusinessLogicException($"Fel adresstyp - {adresstyp.Visningstext()} f�rv�ntades!");
        }

        public void BytTelefonnummer(string telefonnummer, Metadata metadata)
        {
            Telefon.Telefonnummer = telefonnummer;
            Metadata = metadata;
        }

        public void BytEpostAdress(string epostAdress, Metadata metadata)
        {
            Mail.MailAdress = epostAdress;
            Metadata = metadata;
        }

        public void BytGatuadress(string adressRad1, string postnummer, string stad, string land, Metadata metadata)
        {
            Gatuadress.AdressRad1 = adressRad1;
            Gatuadress.Postnummer = postnummer;
            Gatuadress.Stad = stad;
            Gatuadress.Land = land;
            Metadata = metadata;
        }
    }
}

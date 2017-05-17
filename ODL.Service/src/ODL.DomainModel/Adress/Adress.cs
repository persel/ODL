using System;
using ODL.DomainModel.Common;
using ODL.DomainModel.Person;

namespace ODL.DomainModel.Adress
{
    public class Adress
    {
        public int Id { get; private set; }

        public Metadata Metadata { get; private set; }
        
        public virtual Adressvariant Adressvariant { get; private set; }

        public virtual Gatuadress Gatuadress { get; private set; }

        public virtual Epost Epost { get; private set; }

        public virtual Telefon Telefon { get; private set; }

        public virtual OrganisationAdress OrganisationAdress { get; private set; }

        public virtual PersonAdress PersonAdress { get; private set; }

        public bool Ny => Id == 0;

        public static Adress SkapaNyGatuadress(string adressRad1, string postnummer, string stad, string land, Adressvariant variant, Metadata metadata, Adressinnehavare adressinnehavare)
        {
            VerifieraAdressTyp(variant, Adresstyp.Gatuadress);
            
            var gatuadress = new Gatuadress(adressRad1, postnummer, stad, land);
            var adress = new Adress
            {
                Gatuadress = gatuadress,
                Adressvariant = variant,
                Metadata = metadata
            };

            adress.KopplaTillInnehavare(adressinnehavare);
            
            return adress;
        }

        public static Adress SkapaNyEpostAdress(string epostAdress, Adressvariant variant, Metadata metadata, Adressinnehavare adressinnehavare)
        {
            VerifieraAdressTyp(variant, Adresstyp.EpostAdress);

            var epost = new Epost(epostAdress);
            var adress = new Adress
            {
                Epost = epost,
                Adressvariant = variant,
                Metadata = metadata
            };

            adress.KopplaTillInnehavare(adressinnehavare);

            return adress;
        }

        public static Adress SkapaNyTelefonAdress(string telefonnummer, Adressvariant variant, Metadata metadata, Adressinnehavare adressinnehavare)
        {
            VerifieraAdressTyp(variant, Adresstyp.Telefon);

            var telefon = new Telefon(telefonnummer);
            var adress = new Adress
            {
                Telefon = telefon,
                Adressvariant = variant,
                Metadata = metadata
            };

            adress.KopplaTillInnehavare(adressinnehavare);

            return adress;
        }

        private static void VerifieraAdressTyp(Adressvariant variant, Adresstyp adresstyp)
        {
            if (variant.Adresstyp() != adresstyp)
                throw new BusinessLogicException($"Fel adresstyp - {adresstyp.Visningstext()} förväntades.");
        }

        public void BytTelefonnummer(string telefonnummer, Metadata metadata)
        {
            Telefon.Telefonnummer = telefonnummer;
            Metadata = metadata;
        }

        public void BytEpostAdress(string epostAdress, Metadata metadata)
        {
            Epost.EpostAdress = epostAdress;
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

        private void KopplaTillInnehavare(Adressinnehavare adressinnehavare)
        {
            // Hmm, kanske går att använda vanlig OO/polymorfi, kompatibelt med Entity Framework, istället för att titta på typen som här...
            // Men ev ej möjligt eftersom det är två olika tabeller i DB för PersonAdress och OrganisationAdress.

            if (adressinnehavare.IsPerson)
                PersonAdress = new PersonAdress { PersonId = adressinnehavare.Id };
            else if (adressinnehavare.IsOrganisation)
                OrganisationAdress = new OrganisationAdress { OrganisationId = adressinnehavare.Id };
        }
    }
}

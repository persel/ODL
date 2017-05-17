using System;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Adress
{
    public static class AdressvariantExtensions
    {
        public static Adresstyp Adresstyp(this Adressvariant adressvariant)
        {
            if (adressvariant == Adressvariant.Folkbokforingsadress) return DomainModel.Adress.Adresstyp.Gatuadress;
            if (adressvariant == Adressvariant.AdressArbete) return DomainModel.Adress.Adresstyp.Gatuadress;
            if (adressvariant == Adressvariant.Leveransadress) return DomainModel.Adress.Adresstyp.Gatuadress;
            if (adressvariant == Adressvariant.Faktureringsadress) return DomainModel.Adress.Adresstyp.Gatuadress;
            if (adressvariant == Adressvariant.EpostAdressArbete) return DomainModel.Adress.Adresstyp.EpostAdress;
            if (adressvariant == Adressvariant.EpostAdressPrivat) return DomainModel.Adress.Adresstyp.EpostAdress;
            if (adressvariant == Adressvariant.MobilArbete) return DomainModel.Adress.Adresstyp.Telefon;
            if (adressvariant == Adressvariant.MobilPrivat) return DomainModel.Adress.Adresstyp.Telefon;
            if (adressvariant == Adressvariant.TelefonArbete) return DomainModel.Adress.Adresstyp.Telefon;
            if (adressvariant == Adressvariant.TelefonPrivat) return DomainModel.Adress.Adresstyp.Telefon;
            if (adressvariant == Adressvariant.Facebook) return DomainModel.Adress.Adresstyp.Url;
            if (adressvariant == Adressvariant.Linkedin) return DomainModel.Adress.Adresstyp.Url;

           throw new ArgumentException($"Adressvarianten '{adressvariant.Visningstext()}' saknar Adresstyp!");
        }
    }
}

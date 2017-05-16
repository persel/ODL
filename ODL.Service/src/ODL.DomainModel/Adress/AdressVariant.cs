
using System;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Adress
{
    // TODO: Eventuellt refaktorera Adressvariant som Value Object, tillåt nya varianter dynamiskt via Admin-gui etc.
    public enum Adressvariant
    {

        [Visningstext("Folkbokföringsadress")] Folkbokforingsadress = 1,

        [Visningstext("Adress arbete")] AdressArbete = 2,

        [Visningstext("Leveransadress")] Leveransadress = 3,

        [Visningstext("Faktureringsadress")] Faktureringsadress = 4,

        [Visningstext("Epost-adress arbete")] EpostAdressArbete = 5,

        [Visningstext("Epost-adress privat")] EpostAdressPrivat = 6,

        [Visningstext("Mobil arbete")] MobilArbete = 7,

        [Visningstext("Mobil privat")] MobilPrivat = 8,

        [Visningstext("Telefon arbete")] TelefonArbete = 9,

        [Visningstext("Telefon privat")] TelefonPrivat = 10,

        [Visningstext("Facebook")] Facebook = 11,

        [Visningstext("Linkedin")] Linkedin = 12
    }

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

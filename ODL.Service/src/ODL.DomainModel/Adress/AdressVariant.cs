
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Adress
{
    // TODO: Denna b�r refaktoreras till en Value Object - vi ska inte skapa nya poster i db vid persistering av Adress. 
    // TODO: Helst ocks� kontrollera instansieringen, jfr. Adresstyp, som dock �r en enum och har "fast antal" v�rden.
    public enum Adressvariant
    {

        [Visningstext("Folkbokf�ringsadress")] Folkbokforingsadress = 1,

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
}

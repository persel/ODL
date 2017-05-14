using ODL.DomainModel.Common;

namespace ODL.DomainModel.Adress
{
    public enum Adresstyp
    {
        [Visningstext("Gatuadress")]
        Gatuadress = 1,

        [Visningstext("Epost-adress")]
        EpostAdress = 2,

        [Visningstext("Telefon")]
        Telefon = 3,

        [Visningstext("Url")]
        Url = 4
    }

}
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Adress
{
    public enum AdressTyp
    {
        [Visningstext("Gatuadress")]
        Gatuadress = 1,

        [Visningstext("Epost-adress")]
        MailAdress = 2,

        [Visningstext("Telefon")]
        Telefon = 3,

        [Visningstext("Facebook")]
        Facebook = 4
    }

}
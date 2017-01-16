using System;

namespace ODL.DomainModel.Adress
{
    public enum AdressTyp
    {
        GatuAdress = 1,
        MailAdress = 2,
        Telefon = 3,
        Facebook = 4
    }

    public static class AdressTypExtensions
    {
        public static string DisplayName(this AdressTyp adressTyp)
        {
            switch (adressTyp)
            {
                case AdressTyp.GatuAdress:
                    return "Gatuadress";
                case AdressTyp.MailAdress:
                    return "Epostadress";
                case AdressTyp.Telefon:
                    return "Telefon";
                case AdressTyp.Facebook:
                    return "Facebook";
                default:
                    throw new ArgumentOutOfRangeException($"Ogiltigt värde: '{adressTyp}'");
            }
        }
    }
}
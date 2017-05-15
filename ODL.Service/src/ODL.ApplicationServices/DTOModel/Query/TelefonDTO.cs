using ODL.DomainModel.Adress;

namespace ODL.ApplicationServices.DTOModel.Query
{
    public class TelefonDTO 
    {

        public static TelefonDTO FromTelefon(Telefon telefon)
        {
            if (telefon == null)
                return null;

            var telefonDTO = new TelefonDTO();
            telefonDTO.Telefonnummer = telefon.Telefonnummer;

            return telefonDTO;
        }

        public string Telefonnummer { get; set; }
    }
}
using ODL.DomainModel.Adress;

namespace ODL.ApplicationServices.DTOModel.Query
{
    public class GatuadressDTO
    {
        public static GatuadressDTO FromGatuadress(Gatuadress gatuadress)
        {
            if (gatuadress == null)
                return null;

            var gatuadressDTO = new GatuadressDTO();
            gatuadressDTO.AdressRad1 = gatuadress.AdressRad1;
            gatuadressDTO.AdressRad2 = gatuadress.AdressRad2;
            gatuadressDTO.AdressRad3 = gatuadress.AdressRad3;
            gatuadressDTO.AdressRad4 = gatuadress.AdressRad4;
            gatuadressDTO.AdressRad5 = gatuadress.AdressRad5;
            gatuadressDTO.Postnummer = gatuadress.Postnummer;
            gatuadressDTO.Stad = gatuadress.Stad;
            gatuadressDTO.Land = gatuadress.Land;

            return gatuadressDTO;
        }


        public string AdressRad1 { get; set; }

        public string AdressRad2 { get; set; }

        public string AdressRad3 { get; set; }

        public string AdressRad4 { get; set; }

        public string AdressRad5 { get; set; }

        public string Postnummer { get; set; }

        public string Stad { get; set; }

        public string Land { get; set; }
    }
}
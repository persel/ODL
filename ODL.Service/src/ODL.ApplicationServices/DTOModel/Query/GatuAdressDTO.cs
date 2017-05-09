using ODL.DomainModel.Adress;

namespace ODL.ApplicationServices.DTOModel.Query
{
    public class GatuadressDTO
    {
        public static GatuadressDTO FromGatuadress(Gatuadress gatuadress)
        {
            if (gatuadress == null)
                return null;

            var gatuAdressDTO = new GatuadressDTO();
            gatuAdressDTO.AdressRad1 = gatuadress.AdressRad1;
            gatuAdressDTO.AdressRad2 = gatuadress.AdressRad2;
            gatuAdressDTO.AdressRad3 = gatuadress.AdressRad3;
            gatuAdressDTO.AdressRad4 = gatuadress.AdressRad4;
            gatuAdressDTO.AdressRad5 = gatuadress.AdressRad5;
            gatuAdressDTO.Postnummer = gatuadress.Postnummer;
            gatuAdressDTO.Stad = gatuadress.Stad;
            gatuAdressDTO.Land = gatuadress.Land;

            return gatuAdressDTO;
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
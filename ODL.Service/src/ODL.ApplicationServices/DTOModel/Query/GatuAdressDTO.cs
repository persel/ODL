using ODL.DomainModel.Adress;

namespace ODL.ApplicationServices.DTOModel.Query
{
    public class GatuAdressDTO
    {
        public static GatuAdressDTO FromGatuadress(GatuAdress gatuAdress)
        {
            if (gatuAdress == null)
                return null;

            var gatuAdressDTO = new GatuAdressDTO();
            gatuAdressDTO.AdressRad1 = gatuAdress.AdressRad1;
            gatuAdressDTO.AdressRad2 = gatuAdress.AdressRad2;
            gatuAdressDTO.AdressRad3 = gatuAdress.AdressRad3;
            gatuAdressDTO.AdressRad4 = gatuAdress.AdressRad4;
            gatuAdressDTO.AdressRad5 = gatuAdress.AdressRad5;
            gatuAdressDTO.Postnummer = gatuAdress.Postnummer;
            gatuAdressDTO.Stad = gatuAdress.Stad;
            gatuAdressDTO.Land = gatuAdress.Land;

            return gatuAdressDTO;
        }


        public string AdressRad1 { get; set; }

        public string AdressRad2 { get; set; }

        public string AdressRad3 { get; set; }

        public string AdressRad4 { get; set; }

        public string AdressRad5 { get; set; }

        public decimal Postnummer { get; set; }

        public string Stad { get; set; }

        public string Land { get; set; }
    }
}
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.DTOModel
{
    public class GatuadressInputDTO : InputDTO
    {
        public int AdressVariantId { get; set; }
        public string AdressRad1 { get; set; }
        public string AdressRad2 { get; set; }
        public string AdressRad3 { get; set; }
        public string AdressRad4 { get; set; }
        public string AdressRad5 { get; set; }
        public int Postnummer { get; set; }
        public string Stad { get; set; }
        public string Land { get; set; }
    }
}
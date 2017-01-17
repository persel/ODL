using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.DTOModel
{
    public class TelefonInputDTO : InputDTO
    {
        public int AdressVariantId { get; set; }
        public string Telefonnummer { get; set; }
    }
}
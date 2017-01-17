using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.DTOModel
{
    public class MailInputDTO : InputDTO
    {
        public int AdressVariantId { get; set; }
        public string MailAdress { get; set; }
    }
}
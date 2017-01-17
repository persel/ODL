using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.DTOModel
{
    public abstract class AdressInputDTO : InputDTO
    {
        public GatuadressInputDTO GatuadressInput { get; set; }
        public MailInputDTO MailInput { get; set; }
        public TelefonInputDTO TelefonInput { get; set; }

        //public bool IsPersonAdress { get; }
        //public bool IsOrganisationAdress { get; }
    }
}
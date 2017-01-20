using ODL.ApplicationServices.DTOModel.Load;
using ODL.DomainModel.Adress;

namespace ODL.ApplicationServices.DTOModel
{
    public abstract class AdressInputDTO : InputDTO
    {
        public string AdressVariant { get; set; }
        public GatuadressInputDTO GatuadressInput { get; set; }
        public MailInputDTO MailInput { get; set; }
        public TelefonInputDTO TelefonInput { get; set; }

        //public bool IsPersonAdress { get; }
        //public bool IsOrganisationAdress { get; }
    }
}
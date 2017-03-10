using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public class MailInputValidator : Validator<MailInputDTO>
    {

        public MailInputValidator()
        {
            RuleFor(adress => adress.MailAdress).NotNullOrWhiteSpace().isValidMailAdress();
        }
    }
}

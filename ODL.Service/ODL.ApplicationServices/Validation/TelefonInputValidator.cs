using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public class TelefonInputValidator : Validator<TelefonInputDTO>
    {
        public TelefonInputValidator()
        {
            RuleFor(adress => adress.Telefonnummer).NotNullOrWhiteSpace().WithinMaxLength(255);
        }
    }
}

using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public class EpostInputValidator : Validator<EpostInputDTO>
    {

        public EpostInputValidator()
        {
            RuleFor(adress => adress.EpostAdress).NotNullOrWhiteSpace().OgiltigEpostAdress();
        }
    }
}

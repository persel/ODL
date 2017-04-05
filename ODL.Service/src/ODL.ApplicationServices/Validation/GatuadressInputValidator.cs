using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public class GatuadressInputValidator : Validator<GatuadressInputDTO>
    {
        public GatuadressInputValidator()
        {
            RuleFor(adress => adress.AdressRad1).NotNullOrWhiteSpace().WithinMaxLength(255);
            RuleFor(adress => adress.AdressRad2).WithinMaxLength(255);
            RuleFor(adress => adress.AdressRad3).WithinMaxLength(255);
            RuleFor(adress => adress.AdressRad4).WithinMaxLength(255);
            RuleFor(adress => adress.AdressRad5).WithinMaxLength(255);
            RuleFor(adress => adress.Postnummer).NotNullOrWhiteSpace().ExactLength(5);
            RuleFor(adress => adress.Stad).NotNullOrWhiteSpace().WithinMaxLength(255);
            RuleFor(adress => adress.Land).WithinMaxLength(255);
        }
    }
}

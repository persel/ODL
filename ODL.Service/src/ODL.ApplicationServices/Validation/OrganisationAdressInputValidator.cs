using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public class OrganisationAdressInputValidator : Validator<OrganisationAdressInputDTO> 
    {

        public OrganisationAdressInputValidator()
        {
            RuleFor(resEnhet => resEnhet.KostnadsstalleNr).NotNullOrWhiteSpace();

        }
    }
}

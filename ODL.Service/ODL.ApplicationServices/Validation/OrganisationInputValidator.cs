using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public class OrganisationInputValidator : Validator<OrganisationInputDTO> 
    {
        // TODO: OBS!  Vid persistering måste vi verifiera att vi har uppdateringsinfo ifall detta objekt redan finns i db, eftersom det då är en uppdatering!?
        // Alt. låt uppdateringinfo vara NOT NULL (samma som skapandeinfo vid ny) ?

        public OrganisationInputValidator()
        {
            RuleFor(organisation => organisation.Namn).NotNullOrEmpty().WithinMaxLength(255);
            //RuleFor(organisation => organisation.OrgId).NotNull().WithinMaxLength(50);
            RequireMetadata();
        }
    }
}

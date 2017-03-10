using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public class ResultatenhetInputValidator : Validator<ResultatenhetInputDTO>
    {
        // TODO: OBS!  Vid persistering måste vi verifiera att vi har uppdateringsinfo ifall detta objekt redan finns i db, eftersom det då är en uppdatering!?
        // Alt. låt uppdateringinfo vara NOT NULL (samma som skapandeinfo vid ny) ?

        public ResultatenhetInputValidator()
        {
            RuleFor(resEnhet => resEnhet.Namn).NotNullOrWhiteSpace().WithinMaxLength(255);
            AboveZero(resEnhet => resEnhet.KostnadsstalleNr);
            RuleFor(resEnhet => resEnhet.Typ).NotNullOrWhiteSpace().WithinMaxLength(5);
            RequireMetadata();
        }
    }
}

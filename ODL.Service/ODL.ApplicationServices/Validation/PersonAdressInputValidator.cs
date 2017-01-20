using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public class PersonAdressInputValidator : Validator<PersonAdressInputDTO>
    {
        // TODO: OBS!  Vid persistering måste vi verifiera att vi har uppdateringsinfo ifall detta objekt redan finns i db, eftersom det då är en uppdatering!?
        // Alt. låt uppdateringinfo vara NOT NULL (samma som skapandeinfo vid ny) ?

        public PersonAdressInputValidator()
        {
            RuleFor(person => person.Personnummer).NotNullOrEmpty().WithinMaxLength(12);
            //RequireMetadata();
        }
    }
}

using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public class PersonInputValidator : Validator<PersonInputDTO>
    {
        // TODO: OBS!  Vid persistering måste vi verifiera att vi har uppdateringsinfo ifall detta objekt redan finns i db, eftersom det då är en uppdatering!?
        // Alt. låt uppdateringinfo vara NOT NULL (samma som skapandeinfo vid ny) ?

        public PersonInputValidator()
        {
            //AddRule(person => !string.IsNullOrEmpty(person.Fornamn), "Förnamn saknas.");
            //NotNull(person => person.Efternamn);

            RuleFor(person => person.Fornamn).NotNullOrEmpty().WithinMaxLength(255);
            RuleFor(person => person.Mellannamn).WithinMaxLength(255);
            RuleFor(person => person.Efternamn).NotNullOrEmpty().WithinMaxLength(255);
            RuleFor(person => person.Personnummer).NotNullOrEmpty().WithinMaxLength(12);
            RuleFor(person => person.Alias).NotNullOrEmpty().WithinMaxLength(10);
            AddStandardRules();
        }
    }
}

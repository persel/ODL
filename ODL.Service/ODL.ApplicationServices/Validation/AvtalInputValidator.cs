using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public class AvtalInputValidator : Validator<AvtalInputDTO>
    {

        // TODO: OBS!  Vid persistering måste vi kräva att vi får uppdateringsinfo ifall detta objekt redan finns i db, eftersom det då är en uppdatering!?
        // Alt. låt uppdateringinfo vara NOT NULL (samma som skapandeinfo vid ny) ?

        public AvtalInputValidator()
        {
            //AddRule(avtal => avtal.Avtalskod != null &&  avtal.Avtalskod.Length > 50, "Avtalskod över 50 tecken");
            RuleFor(avtal => avtal.Avtalskod).WithinMaxLength(50);
            RuleFor(avtal => avtal.Avtalstext).WithinMaxLength(50);
            RuleFor(avtal => avtal.BefText).WithinMaxLength(50);
            RuleFor(avtal => avtal.DeltidFranvaro).WithinMaxLength(10);
            RuleFor(avtal => avtal.SjukP).WithinMaxLength(10);
            RuleFor(avtal => avtal.LoneTyp).WithinMaxLength(10);

            RuleFor(avtal => avtal.TjledigFran).ValidDateFormat();
            RuleFor(avtal => avtal.TjledigTom).ValidDateFormat();
            RuleFor(avtal => avtal.LonDatum).ValidDateFormat();
            RuleFor(avtal => avtal.Anstallningsdatum).ValidDateFormat();
            RuleFor(avtal => avtal.Avgangsdatum).ValidDateFormat();
            
            AddRule(avtal => string.IsNullOrEmpty(avtal.AnstalldPersonId) || string.IsNullOrEmpty(avtal.KonsultPersonId), "Avtalet kan ej tillhöra både anställd och konsult.");

            AddStandardRules();
        }
    }
}

using System.Linq;
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

            AddRule(avtal => !(string.IsNullOrEmpty(avtal.AnstalldPersonnummer) && string.IsNullOrEmpty(avtal.KonsultPersonnummer)), "Avtalet måste innehålla ett personnummer.");
            AddRule(avtal => string.IsNullOrEmpty(avtal.AnstalldPersonnummer) || string.IsNullOrEmpty(avtal.KonsultPersonnummer), "Avtalet kan ej tillhöra både anställd och konsult.");
            AddRule(avtal => avtal.Kostnadsstallen.Any(), "Avtalet måste ange minst ett kostnadsställenummer.");

            AddStandardRules();
        }
    }
}

using System.Collections.Generic;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.Validation
{
    public class AdressInputValidator : Validator<AdressInputDTO>
    {
        // TODO: OBS!  Vid persistering måste vi verifiera att vi har uppdateringsinfo ifall detta objekt redan finns i db, eftersom det då är en uppdatering!?
        // Alt. låt uppdateringinfo vara NOT NULL (samma som skapandeinfo vid ny) ?

        public AdressInputValidator()
        {
            RequireMetadata();
        }

        public override List<ValidationError> Validate(AdressInputDTO subject)
        {

            var allErrors = base.Validate(subject);

            var gatuadress = subject.GatuadressInput;
            var epostadress = subject.MailInput;
            var telefon = subject.TelefonInput;

            if (!string.IsNullOrEmpty(gatuadress?.AdressRad1))
                new GatuadressInputValidator().Validate(gatuadress, allErrors);

            if (!string.IsNullOrEmpty(epostadress?.MailAdress))
                new MailInputValidator().Validate(epostadress, allErrors);

            if (!string.IsNullOrEmpty(telefon?.Telefonnummer))
                new TelefonInputValidator().Validate(telefon, allErrors);

            return allErrors;
        }


    }
}

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

            var endastEnAngiven = ((gatuadress != null) ^ (epostadress != null) ^ (telefon != null));
            if (!endastEnAngiven)
                allErrors.Add(new ValidationError("Endast en av gatuadress, epostadress eller telefon får anges!"));

                //if (!((gatuadress != null) ^ (epostadress != null) ^ (telefon != null)))
            //    allErrors.Add(new ValidationError("Endast en av gatuadress, epostadress eller telefon får anges!"));
            else if (gatuadress != null)
                new GatuadressInputValidator().Validate(gatuadress, allErrors);

            else if (epostadress != null)
                new MailInputValidator().Validate(epostadress, allErrors);

            else if (telefon != null)
                new TelefonInputValidator().Validate(telefon, allErrors);

            return allErrors;
        }


    }
}

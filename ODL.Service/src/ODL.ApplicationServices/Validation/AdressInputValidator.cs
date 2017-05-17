using System.Collections.Generic;
using ODL.ApplicationServices.DTOModel;

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

            var personEllerResultatenhet = subject.AvserPerson ^ subject.AvserResultatenhet; // Exclusive OR

            if (!personEllerResultatenhet)
                allErrors.Add(new ValidationError("Adressen måste ange antingen en person eller en resultatenhet."));
            else if(subject.AvserPerson && subject.Personnummer.Length != 12)
                allErrors.Add(new ValidationError("Personnumret som angivits för adressen är ej giltigt."));
            else if (subject.AvserResultatenhet && subject.KostnadsstalleNr.Length != 6)
                allErrors.Add(new ValidationError("Kostnadsställenumret som angivits för adressen ej giltigt."));

            var gatuadress = subject.GatuadressInput;
            var epostadress = subject.EpostInput;
            var telefon = subject.TelefonInput;

            var endastEnAngiven = (gatuadress != null) ^ (epostadress != null) ^ (telefon != null);
            if (!endastEnAngiven)
                allErrors.Add(new ValidationError("Endast en av gatuadress, epostadress eller telefon får anges!"));

            else if (gatuadress != null)
                new GatuadressInputValidator().Validate(gatuadress, allErrors);

            else if (epostadress != null)
                new EpostInputValidator().Validate(epostadress, allErrors);

            else if (telefon != null)
                new TelefonInputValidator().Validate(telefon, allErrors);

            return allErrors;
        }


    }
}

using System.Collections.Generic;
using System.Linq;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.Validation;

namespace ODL.ApplicationServices.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class AdressInputValidatorTests
    {
        [Test]
        public void TestValidatePersonAdressTelefon()
        {
            var personAdress = CreatePersonAdress();

            var brokenRules = new PersonAdressInputValidator().Validate(personAdress);
            new AdressInputValidator().Validate(personAdress, brokenRules);

            Assert.That(brokenRules.Count, Is.EqualTo(3));

            Assert.That(
                brokenRules.Any(
                    ve =>
                        ve.Message.Equals(
                            "Fältet 'AdressInputDTO.SkapadDatum' har ej korrekt datumformat ('yyyy-MM-dd HH:mm').")));
            Assert.That(
                brokenRules.Any(
                    ve =>
                        ve.Message.Equals(
                            "Fältet 'AdressInputDTO.UppdateradDatum' har ej korrekt datumformat ('yyyy-MM-dd HH:mm').")));
        }

        [Test]
        public void TestValidateOrganisationAdress()
        {

            var organisationAdress = CreateOrganisationAdress();

            var brokenRules = new OrganisationAdressInputValidator().Validate(organisationAdress);
            new AdressInputValidator().Validate(organisationAdress, brokenRules);

            Assert.That(brokenRules.Count, Is.EqualTo(3));

            //Assert.That(brokenRules.Any(ve =>ve.Message.Equals("Fältet 'AdressInputDTO.SkapadDatum' har ej korrekt datumformat ('yyyy-MM-dd HH:mm').")));
            //Assert.That(brokenRules.Any(ve =>ve.Message.Equals("Fältet 'AdressInputDTO.UppdateradDatum' har ej korrekt datumformat ('yyyy-MM-dd HH:mm').")));
        }

        private PersonAdressInputDTO CreatePersonAdress(GatuadressInputDTO gatuadressInput, MailInputDTO mailInput, TelefonInputDTO telefonInput)
        {
            var personAdress = new PersonAdressInputDTO();
            if (gatuadressInput != null)
            {
                var personGatuadress = new PersonAdressInputDTO
                {
                    Personnummer = "123456-7788",
                    AdressVariant = "Mobil Arbete",
                    GatuadressInput = null,
                    MailInput = null,
                    TelefonInput = new TelefonInputDTO { Telefonnummer = "" },
                    SystemId = null,
                    UppdateradDatum = "2017-01-20",
                    UppdateradAv = "MAH",
                    SkapadDatum = "2017 - 01 - 20 12:00",
                    SkapadAv = "MAH"
                };
                personAdress = personGatuadress;
            }
            if (mailInput != null)
            {
                var personEpostadress = new PersonAdressInputDTO
                {
                    Personnummer = "123456-7788",
                    AdressVariant = "Mobil Arbete",
                    GatuadressInput = null,
                    MailInput = null,
                    TelefonInput = new TelefonInputDTO { Telefonnummer = "" },
                    SystemId = null,
                    UppdateradDatum = "2017-01-20",
                    UppdateradAv = "MAH",
                    SkapadDatum = "2017 - 01 - 20 12:00",
                    SkapadAv = "MAH"
                };
                personAdress = personEpostadress;
            }
            if (telefonInput != null)
            {
                var personTelefon = new PersonAdressInputDTO
                {
                    Personnummer = "123456-7788",
                    AdressVariant = "Mobil Arbete",
                    GatuadressInput = null,
                    MailInput = null,
                    TelefonInput = new TelefonInputDTO { Telefonnummer = "" },
                    SystemId = null,
                    UppdateradDatum = "2017-01-20",
                    UppdateradAv = "MAH",
                    SkapadDatum = "2017 - 01 - 20 12:00",
                    SkapadAv = "MAH"
                };
                personAdress =  personTelefon;
            }
            return personAdress;
        }

        private OrganisationAdressInputDTO CreateOrganisationAdress()
        {
            throw new System.NotImplementedException();
        }
    }
}

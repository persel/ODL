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
        public void TestValidatePersonAdressGatuAdress()
        {
            var personAdress = CreatePersonAdress(new GatuadressInputDTO(), null, null);

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
        public void TestValidatePersonAdressMail()
        {
            var personAdress = CreatePersonAdress(null, new MailInputDTO(), null);

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
        public void TestValidatePersonAdressTelefon()
        {
            var personAdress = CreatePersonAdress(null,null, new TelefonInputDTO());

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
        public void TestValidateOrganisationAdressGatuAdress()
        {

            var organisationAdress = CreateOrganisationAdress(new GatuadressInputDTO(), null, null);

            var brokenRules = new OrganisationAdressInputValidator().Validate(organisationAdress);
            new AdressInputValidator().Validate(organisationAdress, brokenRules);

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

        private PersonAdressInputDTO CreatePersonAdress(GatuadressInputDTO gatuadressInput, MailInputDTO mailInput, TelefonInputDTO telefonInput)
        {
            var personAdress = new PersonAdressInputDTO();
            if (gatuadressInput != null)
            {
                var personGatuadress = new PersonAdressInputDTO
                {
                    Personnummer = "123456-7788",
                    AdressVariant = "LeveransAdress",
                    GatuadressInput = new GatuadressInputDTO
                    {
                      AdressRad1  = "Gatan 2",
                      Stad = "Knivsta",
                      Land = "USA"
                    },
                    MailInput = null,
                    TelefonInput = null,
                    SystemId = null
                };
                personAdress = personGatuadress;
            }
            if (mailInput != null)
            {
                var personEpostadress = new PersonAdressInputDTO
                {
                    Personnummer = "123456-7788",
                    AdressVariant = "MailAdress Privat",
                    GatuadressInput = null,
                    MailInput = new MailInputDTO { MailAdress = "eva.ek@home..se"},
                    TelefonInput = null,
                    SystemId = null
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
                    SystemId = null
                };
                personAdress =  personTelefon;
            }
            return personAdress;
        }

        private OrganisationAdressInputDTO CreateOrganisationAdress(GatuadressInputDTO gatuadressInput, MailInputDTO mailInput, TelefonInputDTO telefonInput)
        {
            var organisationAdress = new OrganisationAdressInputDTO();
            if (gatuadressInput != null)
            {
                var organisationGatuadress = new OrganisationAdressInputDTO
                {
                    KostnadsstalleNr = "338111",
                    AdressVariant = "FaktureringsAdress",
                    GatuadressInput = new GatuadressInputDTO
                    {
                        AdressRad1 = "Gatan 2",
                        Stad = "Knivsta",
                        Land = "USA"
                    },
                    MailInput = null,
                    TelefonInput = null,
                    SystemId = null
                };
                organisationAdress = organisationGatuadress;
            }
            if (mailInput != null)
            {
                var organisationEpostadress = new OrganisationAdressInputDTO
                {
                    KostnadsstalleNr = "338111",
                    AdressVariant = "MailAdress Arbete",
                    GatuadressInput = null,
                    MailInput = new MailInputDTO { MailAdress = "tandis@home..se" },
                    TelefonInput = null,
                    SystemId = null
                };
                organisationAdress = organisationEpostadress;
            }
            if (telefonInput != null)
            {
                var organisationTelefon = new OrganisationAdressInputDTO
                {
                    KostnadsstalleNr = "338111",
                    AdressVariant = "Mobil Arbete",
                    GatuadressInput = null,
                    MailInput = null,
                    TelefonInput = new TelefonInputDTO { Telefonnummer = "" },
                    SystemId = null
                };
                organisationAdress = organisationTelefon;
            }
            return organisationAdress;
        }
    }
}

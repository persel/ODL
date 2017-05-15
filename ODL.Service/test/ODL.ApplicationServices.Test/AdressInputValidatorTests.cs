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
        public void TestValidatePersonAdressGatuadress()
        {
            var personAdress = CreatePersonAdress(new GatuadressInputDTO(), null, null);

            var brokenRules = new PersonAdressInputValidator().Validate(personAdress);
            new AdressInputValidator().Validate(personAdress, brokenRules);

            Assert.That(brokenRules.Count, Is.EqualTo(3));

            Assert.That(
                brokenRules.Any(
                    ve =>
                        ve.Message.Equals(
                            "Fältet 'GatuadressInputDTO.Postnummer' saknar värde.")));
            Assert.That(
                brokenRules.Any(
                    ve =>
                        ve.Message.Equals(
                            "Fältet 'AdressInputDTO.SkapadAv' saknar värde.")));
        }


        [Test]
        public void TestValidateOrganisationAdressGatuadress()
        {

            var organisationAdress = CreateOrganisationAdress(new GatuadressInputDTO(), null, null);

            var brokenRules = new OrganisationAdressInputValidator().Validate(organisationAdress);
            new AdressInputValidator().Validate(organisationAdress, brokenRules);

            Assert.That(brokenRules.Count, Is.EqualTo(3));


            Assert.That(
                brokenRules.Any(
                    ve =>
                        ve.Message.Equals(
                            "Fältet 'GatuadressInputDTO.Postnummer' saknar värde.")));
            Assert.That(
                brokenRules.Any(
                    ve =>
                        ve.Message.Equals(
                            "Fältet 'AdressInputDTO.SkapadAv' saknar värde.")));
        }

        private PersonAdressInputDTO CreatePersonAdress(GatuadressInputDTO gatuadressInput, EpostInputDTO epostInput, TelefonInputDTO telefonInput)
        {
            var personAdress = new PersonAdressInputDTO();
            if (gatuadressInput != null)
            {
                var personGatuadress = new PersonAdressInputDTO
                {
                    Personnummer = "123456-7788",
                    Adressvariant = "Leveransadress",
                    GatuadressInput = new GatuadressInputDTO
                    {
                      AdressRad1  = "Gatan 2",
                      Stad = "Knivsta",
                      Land = "USA"
                    },
                    EpostInput = null,
                    TelefonInput = null,
                    SystemId = null
                };
                personAdress = personGatuadress;
            }
            if (epostInput != null)
            {
                var personEpostadress = new PersonAdressInputDTO
                {
                    Personnummer = "123456-7788",
                    Adressvariant = "EpostAdress Privat",
                    GatuadressInput = null,
                    EpostInput = new EpostInputDTO { EpostAdress = "eva.ek@home..se"},
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
                    Adressvariant = "Mobil Arbete",
                    GatuadressInput = null,
                    EpostInput = null,
                    TelefonInput = new TelefonInputDTO { Telefonnummer = "" },
                    SystemId = null
                };
                personAdress =  personTelefon;
            }
            return personAdress;
        }

        private OrganisationAdressInputDTO CreateOrganisationAdress(GatuadressInputDTO gatuadressInput, EpostInputDTO epostInput, TelefonInputDTO telefonInput)
        {
            var organisationAdress = new OrganisationAdressInputDTO();
            if (gatuadressInput != null)
            {
                var organisationGatuadress = new OrganisationAdressInputDTO
                {
                    KostnadsstalleNr = "338111",
                    Adressvariant = "FaktureringsAdress",
                    GatuadressInput = new GatuadressInputDTO
                    {
                        AdressRad1 = "Gatan 2",
                        Stad = "Knivsta",
                        Land = "USA"
                    },
                    EpostInput = null,
                    TelefonInput = null,
                    SystemId = null
                };
                organisationAdress = organisationGatuadress;
            }
            if (epostInput != null)
            {
                var organisationEpostadress = new OrganisationAdressInputDTO
                {
                    KostnadsstalleNr = "338111",
                    Adressvariant = "EpostAdress Arbete",
                    GatuadressInput = null,
                    EpostInput = new EpostInputDTO { EpostAdress = "tandis@home..se" },
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
                    Adressvariant = "Mobil Arbete",
                    GatuadressInput = null,
                    EpostInput = null,
                    TelefonInput = new TelefonInputDTO { Telefonnummer = "" },
                    SystemId = null
                };
                organisationAdress = organisationTelefon;
            }
            return organisationAdress;
        }
    }
}

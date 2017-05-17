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
        public void TestValidatePersonGatuadress()
        {
            var personAdress = CreateGatuadress();
            personAdress.Personnummer = "123456-7788";

            var brokenRules = new AdressInputValidator().Validate(personAdress);

            Assert.That(brokenRules.Count, Is.EqualTo(2));

            Assert.That(
                brokenRules.Any(
                    ve =>
                        ve.Message.Equals(
                            "Fältet 'GatuadressInputDTO.Postnummer' saknar värde.")));
            Assert.That(
                brokenRules.Any(
                    ve =>
                        ve.Message.Equals(
                            "Personnumret som angivits för adressen är ej giltigt.")));
        }

        [Test]
        public void TestValidateOrganisationGatuadress()
        {

            var organisationAdress = CreateGatuadress();
            organisationAdress.KostnadsstalleNr = "338111";

            var brokenRules = new AdressInputValidator().Validate(organisationAdress);

            Assert.That(brokenRules.Count, Is.EqualTo(1));
            
            Assert.That(
                brokenRules.Any(
                    ve =>
                        ve.Message.Equals(
                            "Fältet 'GatuadressInputDTO.Postnummer' saknar värde.")));
        }

        [Test]
        public void TestValidateOrganisationEllerPerson()
        {
            var adress = CreateTelefonAdress();
            adress.Personnummer = "197001124554";
            adress.KostnadsstalleNr = "123456";


            var brokenRules = new AdressInputValidator().Validate(adress);

            Assert.That(brokenRules.Count, Is.EqualTo(1));

            Assert.That(
                brokenRules.Any(
                    ve =>
                        ve.Message.Equals(
                            "Adressen måste ange antingen en person eller en resultatenhet.")));
        }

        [Test]
        public void TestValidateEpostAdress()
        {
            var adress = CreateEpostAdress();
            adress.Personnummer = "197001124554";
            
            var brokenRules = new AdressInputValidator().Validate(adress);

            Assert.That(brokenRules.Count, Is.EqualTo(1));

            Assert.That(
                brokenRules.Any(
                    ve =>
                        ve.Message.Equals(
                            "Fältet 'EpostInputDTO.EpostAdress' har ogiltigt epost-format.")));
        }

        private AdressInputDTO CreateGatuadress()
        {
            return new AdressInputDTO
            {
                Adressvariant = "Leveransadress",
                SkapadAv = "ABO",
                SkapadDatum = "2016-02-28 13:45",
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
        }

        private AdressInputDTO CreateEpostAdress()
        {
            return  new AdressInputDTO
            {
                Adressvariant = "EpostAdressPrivat",
                SkapadAv = "ABO",
                SkapadDatum = "2016-02-28 13:45",
                EpostInput = new EpostInputDTO { EpostAdress = "eva.ek@home..se"}
            };
         }

        private AdressInputDTO CreateTelefonAdress()
        { 
            return new AdressInputDTO
            {
                Adressvariant = "MobilArbete",
                SkapadAv = "ABO",
                SkapadDatum = "2016-02-28 13:45",
                TelefonInput = new TelefonInputDTO { Telefonnummer = "070567645" }
            };
        }
    }
}

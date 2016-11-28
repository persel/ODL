using System.Collections.Generic;
using System.Linq;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.ApplicationServices.Validation;

namespace ODL.ApplicationServices.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class AvtalInputValidatorTests
    {
        [Test]
        public void TestValidate()
        {
            var avtal = new AvtalInputDTO
            {
                SystemId = "123456",
                OrganisationId = new[] { "341354262536","5235325325"},
                AnstalldPersonId = "32452",
                KonsultPersonId = "98563", // Ska ej kunna tillhöra både en konsult och en anställd!
                Avtalskod = "KL",
                Avtalstext = "Lorem ipsum",
                ArbetstidVecka = 40,
                Befkod = 3,
                BefText = null,
                Aktiv = false,
                Ansvarig = false,
                Chef = false,
                TjledigFran = null,
                TjledigTom = null,
                Fproc = null,
                DeltidFranvaro = "AB",
                FranvaroProcent = 10.4m,
                SjukP = null,
                GrundArbtidVecka = null,
                AvtalsTyp = 3,
                Lon = 14000,
                LonDatum = "2015-01-99", // Fel datumformat!
                LoneTyp = "B",
                LoneTillagg = 400,
                TimLon = 100,
                Anstallningsdatum = "2015-01-01",
                Avgangsdatum = null,
                SkapadDatum = "2016-09-21",
                SkapadAv = "SNA01"
            };

            var validator = new AvtalInputValidator();

            var brokenRules = validator.Validate(avtal);

            Assert.That(brokenRules.Count, Is.EqualTo(2));

            Assert.That(brokenRules.Any(ve => ve.Message.Equals("Fältet 'AvtalInputDTO.LonDatum' har ej korrekt datumformat ('yyyy-MM-dd'). (Id: 123456)")));
            Assert.That(brokenRules.Any(ve => ve.Message.Equals("Avtalet kan ej tillhöra både anställd och konsult.")));

        }
    }
}

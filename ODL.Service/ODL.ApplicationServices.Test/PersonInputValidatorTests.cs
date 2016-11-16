using System.Collections.Generic;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.ApplicationServices.Validation;

namespace ODL.ApplicationServices.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class PersonInputValidatorTests
    {
        [Test]
        public void TestValidate()
        {
            var person = new PersonInputDTO
            {
                SystemId = "123456",
                Personnummer = "19701230-3456",
                Fornamn = "Anders",
                Mellannamn = "",
                Efternamn = "",
                Alias = null,
                IsKonsult = false,
                IsAnstalld = true,
                UppdateradDatum = null,
                UppdateradAv = null,
                SkapadDatum = null,
                SkapadAv = ""
            };

            var validator = new PersonInputValidator();

            var brokenRules =  validator.Validate(person);

            Assert.That(brokenRules.Count, Is.EqualTo(5));

            Assert.That(brokenRules.Find(ve => ve.Message.Equals("Fältet 'PersonInputDTO.Efternamn' saknar värde. (Id: 123456)")), Is.Not.Null);
            Assert.That(brokenRules.Find(ve => ve.Message.Equals("Fältet 'PersonInputDTO.Personnummer' får innehålla max 12 tecken. (Id: 123456)")), Is.Not.Null);
            Assert.That(brokenRules.Find(ve => ve.Message.Equals("Fältet 'PersonInputDTO.Alias' saknar värde. (Id: 123456)")), Is.Not.Null);
            Assert.That(brokenRules.Find(ve => ve.Message.Equals("Fältet 'PersonInputDTO.SkapadAv' saknar värde. (Id: 123456)")), Is.Not.Null);
            Assert.That(brokenRules.Find(ve => ve.Message.Equals("Fältet 'PersonInputDTO.SkapadDatum' saknar värde. (Id: 123456)")), Is.Not.Null);
        }
    }
}

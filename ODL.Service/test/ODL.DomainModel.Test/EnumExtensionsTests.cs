﻿using ODL.DomainModel.Adress;
using ODL.DomainModel.Common;
using NUnit.Framework;

namespace ODL.DomainModel.Test
{
    

    [TestFixture]
    public class EnumExtensionsTests
    {

        [Test]
        public void Adresstyp_Returnerar_KorrektTyp()
        {
            var variant = Adressvariant.Leveransadress;
            Assert.True(variant.Adresstyp() == Adresstyp.Gatuadress);
            //Assert.That(variant.Adresstyp(), Is.SameAs(Adresstyp.Gatuadress));

            variant = Adressvariant.Facebook;
            Assert.True(variant.Adresstyp() == Adresstyp.Url);
        }

        [Test]
        public void TillEnum_Returnerar_KorrektTyp()
        {
            var variant = "Folkbokforingsadress";
            Assert.True(variant.TillEnum<Adressvariant>() == Adressvariant.Folkbokforingsadress);
        }

        [Test]
        public void Visningstext_Returnerar_Text()
        {
            Assert.That(TestEnumMedTexter.Typ1.Visningstext(), Is.EqualTo("Typ 1"));
            Assert.That(TestEnumMedTexter.Typ3.Visningstext(), Is.EqualTo("Typ 3"));
        }

        [Test]
        public void Visningstext_Returnerar_Null_Om_Text_Saknas()
        {
            Assert.That(TestEnumUtanTexter.Typ2.Visningstext(), Is.Null);
        }
    }

    public enum TestEnumMedTexter
    {
        [Visningstext("Typ 1")]
        Typ1,

        [Visningstext("Typ 2")]
        Typ2,

        [Visningstext("Typ 3")]
        Typ3
    }

    public enum TestEnumUtanTexter
    {
        Typ1,
        Typ2,
        Typ3
    }
}

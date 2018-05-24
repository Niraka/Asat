using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsatUnitTests.Modules.Validation
{
    [TestClass]
    public class Strings
    {
        [TestMethod]
        public void ValidationModuleStringIsNumeric()
        {
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsNumeric("").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsNumeric(" ").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsNumeric(null).IsValid(), false);

            Assert.AreEqual(Asat.Modules.Validation.Strings.IsNumeric("0").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsNumeric("9").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsNumeric("0123").IsValid(), true);

            Assert.AreEqual(Asat.Modules.Validation.Strings.IsNumeric("a").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsNumeric("aa").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsNumeric("a0a").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsNumeric("0a0").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsNumeric("@").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsNumeric(" 123").IsValid(), false);
        }

        [TestMethod]
        public void ValidationModuleStringIsAlphabetical()
        {
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical(" ").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical(null).IsValid(), false);

            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("a").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("z").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("A").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("Z").IsValid(), true);

            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("abcd").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("ABCD").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("abCD").IsValid(), true);
            
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("a0").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("a ").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("a b").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("0a").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphabetical("@").IsValid(), false);
        }

        [TestMethod]
        public void ValidationModuleStringIsAlphanumeric()
        {
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric(" ").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric(null).IsValid(), false);

            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("a").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("z").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("A").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("Z").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("0").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("9").IsValid(), true);

            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("abcd").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("ABCD").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("abCD").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("01").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("abCD01").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric(" abCD01").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("abC D01").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsAlphanumeric("@").IsValid(), false);
        }

        [TestMethod]
        public void ValidationModuleStringIsBoolean()
        {
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean(" ").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean(null).IsValid(), false);

            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("t").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("true").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("T").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("True").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("1").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("f").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("false").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("F").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("False").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("0").IsValid(), true);

            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("2").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("-1").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("@").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsBoolean("a").IsValid(), false);
        }

        [TestMethod]
        public void ValidationModuleStringIsInteger()
        {
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger("").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger(" ").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger(null).IsValid(), false);

            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger("-1").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger("+1").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger("1").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger("97861242").IsValid(), true);

            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger("-").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger("+").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger("--1").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger("++1").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger("a").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsInteger("@").IsValid(), false);
        }

        [TestMethod]
        public void ValidationModuleStringIsFloat()
        {
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat(" ").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat(null).IsValid(), false);

            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("-1").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("+1").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("-.1").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("+.1").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("-1.").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("+1.").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("1").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("1.0").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("97861242").IsValid(), true);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("97861242.0").IsValid(), true);

            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("-").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("+").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat(".").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("..1").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("+..1").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("+.1.1").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("11..").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("--1").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("++1").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("a").IsValid(), false);
            Assert.AreEqual(Asat.Modules.Validation.Strings.IsFloat("@").IsValid(), false);
        }
    }
}

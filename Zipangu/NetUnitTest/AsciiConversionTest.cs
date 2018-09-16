using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zipangu;

namespace NetUnitTest
{
    [TestClass]
    public class AsciiConversionTest
    {
        [TestMethod]
        public void ToWideAscii()
        {
            var Test = TestHelper.CreateAssertion<string, string>(AsciiConversion.ToWideAscii);

            Assert.IsNull(default(string).ToWideAscii());
            Test("", "");
            Test(AsciiConversion.Asciis, AsciiConversion.WideAsciis);

            var chars = EnumerableHelper.RangeChars(char.MinValue, char.MaxValue)
                .Replace(AsciiConversion.Asciis, "");
            foreach (var c in chars)
                Test(c.ToString(), c.ToString());
        }

        [TestMethod]
        public void ToWideAscii_VB()
        {
            void Test(string value) => Assert.AreEqual(value.ToWide_VB(), value.ToWideAscii());
            var Test_VB = TestHelper.CreateAssertion<string, string>(VBStringsHelper.ToWide_VB);

            Test("");
            Test(AsciiConversion.Asciis.Replace(@"\", ""));

            // "\" は変換されません。
            Test_VB(@"\", @"\");
        }
    }
}

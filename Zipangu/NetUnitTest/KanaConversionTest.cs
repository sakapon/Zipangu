using System;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zipangu;

namespace NetUnitTest
{
    [TestClass]
    public class KanaConversionTest
    {
        [TestMethod]
        public void ToHiragana()
        {
            void Test(string value) => Assert.AreEqual(value.ToHiragana_VB(), value.ToHiragana());

            Test("");
            Test(KanaConversion.Asciis);
        }
    }

    public static class VBStringsHelper
    {
        public static string ToHiragana_VB(this string value) =>
            Strings.StrConv(value, VbStrConv.Wide | VbStrConv.Hiragana);
    }
}

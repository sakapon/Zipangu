using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zipangu;

namespace UnitTest
{
    [TestClass]
    public class EncodingHelperTest
    {
        [TestMethod]
        public void ShiftJIS()
        {
            var actual = EncodingHelper.ShiftJIS;
            Assert.AreEqual(932, actual.CodePage);
            Assert.AreEqual("shift_jis", actual.WebName);
        }

        [TestMethod]
        public void ISO2022JP()
        {
            var actual = EncodingHelper.ISO2022JP;
            Assert.AreEqual(50220, actual.CodePage);
            Assert.AreEqual("iso-2022-jp", actual.WebName);
        }

        [TestMethod]
        public void EUCJP()
        {
            var actual = EncodingHelper.EUCJP;
            Assert.AreEqual(51932, actual.CodePage);
            Assert.AreEqual("euc-jp", actual.WebName);
        }

        [TestMethod]
        public void ShiftJIS_GetString()
        {
            var text = "ｼｬ乱Q";
            var bytes = new byte[] { 188, 172, 151, 144, 81 };

            Assert.AreEqual(text, EncodingHelper.ShiftJIS.GetString(bytes));
            CollectionAssert.AreEqual(bytes, EncodingHelper.ShiftJIS.GetBytes(text));
        }
    }
}

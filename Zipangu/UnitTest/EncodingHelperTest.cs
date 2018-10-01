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
        public void ShiftJIS_GetString()
        {
            var text = "ｼｬ乱Q";
            var bytes = new byte[] { 188, 172, 151, 144, 81 };

            Assert.AreEqual(text, EncodingHelper.ShiftJIS.GetString(bytes));
            CollectionAssert.AreEqual(bytes, EncodingHelper.ShiftJIS.GetBytes(text));
        }
    }
}

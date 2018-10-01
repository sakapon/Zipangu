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
            var text = "Aあ漢";
            var bytes = new byte[] { 65, 130, 160, 138, 191 };

            Assert.AreEqual(text, EncodingHelper.ShiftJIS.GetString(bytes));
            CollectionAssert.AreEqual(bytes, EncodingHelper.ShiftJIS.GetBytes(text));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zipangu;

namespace NetUnitTest
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

        [TestMethod]
        public void ISO2022JP_GetString()
        {
            // 半角カタカナは存在しません。
            var text = "シャ乱Q";
            var bytes = new byte[] { 27, 36, 66, 37, 55, 37, 99, 77, 112, 27, 40, 66, 81 };

            Assert.AreEqual(text, EncodingHelper.ISO2022JP.GetString(bytes));
            CollectionAssert.AreEqual(bytes, EncodingHelper.ISO2022JP.GetBytes(text));
        }

        [TestMethod]
        public void EUCJP_GetString()
        {
            var text = "ｼｬ乱Q";
            var bytes = new byte[] { 142, 188, 142, 172, 205, 240, 81 };

            Assert.AreEqual(text, EncodingHelper.EUCJP.GetString(bytes));
            CollectionAssert.AreEqual(bytes, EncodingHelper.EUCJP.GetBytes(text));
        }
    }
}

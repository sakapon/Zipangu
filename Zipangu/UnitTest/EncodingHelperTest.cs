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
    }
}

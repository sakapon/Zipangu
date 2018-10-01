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
            Assert.AreEqual("shift_jis", actual.WebName);
        }
    }
}

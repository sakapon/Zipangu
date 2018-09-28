using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zipangu;

namespace NetUnitTest
{
    [TestClass]
    public class CharConversionTest
    {
        [TestMethod]
        public void HiraganaToKatakana()
        {
            Assert.AreEqual("ベートーヴェン、「ピアノ・ソナタ」。", "ベートーヴェン、「ピアノ・ソナタ」。".Convert());
            Assert.AreEqual("べーとーゔぇん、「ぴあの・そなた」。", "ベートーヴェン、「ピアノ・ソナタ」。".Convert(KanaConv.KatakanaToHiragana));
            Assert.AreEqual("ベートーヴェン、「ピアノ・ソナタ」。", "べーとーゔぇん、「ぴあの・そなた」。".Convert(KanaConv.HiraganaToKatakana));
        }
    }
}

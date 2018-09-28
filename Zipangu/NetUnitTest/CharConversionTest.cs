using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zipangu;

namespace NetUnitTest
{
    [TestClass]
    public class CharConversionTest
    {
        [TestMethod]
        public void Convert()
        {
            var input = "abcＸＹＺゔぃっぷヴィップｳﾞｨｯﾌﾟ";

            Assert.AreEqual(input, input.Convert());
            Assert.AreEqual("abcＸＹＺゔぃっぷゔぃっぷｳﾞｨｯﾌﾟ", input.Convert(KanaConv.KatakanaToHiragana));
            Assert.AreEqual("abcＸＹＺゔぃっぷヴィップゔぃっぷ", input.Convert(KanaConv.HalfKatakanaToHiragana));
            Assert.AreEqual("abcＸＹＺゔぃっぷゔぃっぷゔぃっぷ", input.Convert(KanaConv.AllKanaToHiragana));
            Assert.AreEqual("abcＸＹＺヴィップヴィップｳﾞｨｯﾌﾟ", input.Convert(KanaConv.HiraganaToKatakana));
            Assert.AreEqual("abcＸＹＺゔぃっぷヴィップヴィップ", input.Convert(KanaConv.HalfKatakanaToKatakana));
            Assert.AreEqual("abcＸＹＺヴィップヴィップヴィップ", input.Convert(KanaConv.AllKanaToKatakana));

            Assert.AreEqual("abcXYZゔぃっぷヴィップｳﾞｨｯﾌﾟ", input.Convert(KanaConv.None, AsciiConv.ToNarrow));
            Assert.AreEqual("ａｂｃＸＹＺゔぃっぷヴィップｳﾞｨｯﾌﾟ", input.Convert(KanaConv.None, AsciiConv.ToWide));
        }
    }
}

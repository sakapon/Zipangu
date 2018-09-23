using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zipangu;

namespace NetUnitTest
{
    [TestClass]
    public class KanaConversionTest
    {
        [TestMethod]
        public void HalfKatakanaToHiragana()
        {
            var Test = TestHelper.CreateAssertion<string, string>(KanaConversion.HalfKatakanaToHiragana);

            Test(null, null);
            Test("", "");
            Test(KanaConversion.HalfKatakanas, KanaConversion.HiraganasByHalfKatakana);
            Test(string.Concat(KanaConversion.VoiceableHalfKatakanas.Select(c => $"{c}ﾞ")), KanaConversion.VoicedHiraganas);
            Test(string.Concat(KanaConversion.SemiVoiceableHalfKatakanas.Select(c => $"{c}ﾟ")), KanaConversion.SemiVoicedHiraganas);

            Test("ﾍﾞｰﾄｰｳﾞｪﾝ､｢ﾋﾟｱﾉ･ｿﾅﾀ｣｡", "べーとーゔぇん、「ぴあの・そなた」。");

            var chars = EnumerableHelper.RangeChars(char.MinValue, char.MaxValue)
                .Replace(KanaConversion.HalfKatakanas, "");
            foreach (var c in chars)
                Test(c.ToString(), c.ToString());
        }

        [TestMethod]
        public void HalfKatakanaToHiragana_VB()
        {
            void Test(string value) => Assert.AreEqual(value.ToWideHiragana_VB(), value.HalfKatakanaToHiragana());
            var Test_VB = TestHelper.CreateAssertion<string, string>(VBStringsHelper.ToWideHiragana_VB);

            Test("");
            Test(KanaConversion.HalfKatakanas);
            Test(string.Concat(KanaConversion.VoiceableHalfKatakanas.Replace("ｳ", "").Select(c => $"{c}ﾞ")));
            Test(string.Concat(KanaConversion.SemiVoiceableHalfKatakanas.Select(c => $"{c}ﾟ")));

            Test_VB(null, "");
            // カタカナの "ヴ" に変換されます。
            Test_VB("ｳﾞ", "ヴ");
        }

        [TestMethod]
        public void HalfKatakanaToKatakana()
        {
            var Test = TestHelper.CreateAssertion<string, string>(KanaConversion.HalfKatakanaToKatakana);

            Test(null, null);
            Test("", "");
            Test(KanaConversion.HalfKatakanas, KanaConversion.KatakanasByHalfKatakana);
            Test(string.Concat(KanaConversion.VoiceableHalfKatakanas.Select(c => $"{c}ﾞ")), KanaConversion.VoicedKatakanas);
            Test(string.Concat(KanaConversion.SemiVoiceableHalfKatakanas.Select(c => $"{c}ﾟ")), KanaConversion.SemiVoicedKatakanas);

            Test("ﾍﾞｰﾄｰｳﾞｪﾝ､｢ﾋﾟｱﾉ･ｿﾅﾀ｣｡", "ベートーヴェン、「ピアノ・ソナタ」。");

            var chars = EnumerableHelper.RangeChars(char.MinValue, char.MaxValue)
                .Replace(KanaConversion.HalfKatakanas, "");
            foreach (var c in chars)
                Test(c.ToString(), c.ToString());
        }

        [TestMethod]
        public void HalfKatakanaToKatakana_VB()
        {
            void Test(string value) => Assert.AreEqual(value.ToWideKatakana_VB(), value.HalfKatakanaToKatakana());
            var Test_VB = TestHelper.CreateAssertion<string, string>(VBStringsHelper.ToWideKatakana_VB);

            Test("");
            Test(KanaConversion.HalfKatakanas);
            Test(string.Concat(KanaConversion.VoiceableHalfKatakanas.Select(c => $"{c}ﾞ")));
            Test(string.Concat(KanaConversion.SemiVoiceableHalfKatakanas.Select(c => $"{c}ﾟ")));

            Test_VB(null, "");
        }
    }
}

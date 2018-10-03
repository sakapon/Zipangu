using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zipangu;

namespace NetUnitTest
{
    [TestClass]
    public class KanaConversionTest
    {
        static readonly string AllKanas = EnumerableHelper.RangeChars('　', '〕').Replace("〄", "")
            + EnumerableHelper.RangeChars('ぁ', 'ゖ')
            + EnumerableHelper.RangeChars('゛', 'ヿ')
            + EnumerableHelper.RangeChars('｡', 'ﾟ');

        [TestMethod]
        public void HiraganaToKatakana()
        {
            var Test = TestHelper.CreateAssertion<string, string>(KanaConversion.HiraganaToKatakana);

            Test(null, null);
            Test("", "");
            Test(KanaConversion.Hiraganas, KanaConversion.Katakanas);

            Test("べーとーゔぇん、「ぴあの・そなた」。", "ベートーヴェン、「ピアノ・ソナタ」。");

            var chars = EnumerableHelper.RangeChars(char.MinValue, char.MaxValue)
                .Where(c => !KanaConversion.Hiraganas.Contains(c));
            foreach (var c in chars)
                Test(c.ToString(), c.ToString());
        }

        [TestMethod]
        public void HiraganaToKatakana_VB()
        {
            void Test(string value) => Assert.AreEqual(value.ToKatakana_VB(), value.HiraganaToKatakana());
            var Test_VB = TestHelper.CreateAssertion<string, string>(VBStringsHelper.ToKatakana_VB);

            Test("");
            Test(AllKanas.Replace("ゕゖ", "").Replace("ゟ゠", "").Replace("ヷヸヹヺ", "").Replace("ヿ", ""));

            Test_VB(null, "");
            // "?" に変換されます。
            Test_VB("ゕゖゟ゠ヷヸヹヺヿ", new string('?', 9));
        }

        [TestMethod]
        public void KatakanaToHiragana()
        {
            var Test = TestHelper.CreateAssertion<string, string>(KanaConversion.KatakanaToHiragana);

            Test(null, null);
            Test("", "");
            Test(KanaConversion.Katakanas, KanaConversion.Hiraganas);

            Test("ベートーヴェン、「ピアノ・ソナタ」。", "べーとーゔぇん、「ぴあの・そなた」。");

            var chars = EnumerableHelper.RangeChars(char.MinValue, char.MaxValue)
                .Where(c => !KanaConversion.Katakanas.Contains(c));
            foreach (var c in chars)
                Test(c.ToString(), c.ToString());
        }

        [TestMethod]
        public void KatakanaToHiragana_VB()
        {
            void Test(string value) => Assert.AreEqual(value.ToHiragana_VB(), value.KatakanaToHiragana());
            var Test_VB = TestHelper.CreateAssertion<string, string>(VBStringsHelper.ToHiragana_VB);

            Test("");
            Test(AllKanas.Replace("ゔゕゖ", "").Replace("ゟ゠", "").Replace("ヴヵヶヷヸヹヺ", "").Replace("ヿ", ""));

            Test_VB(null, "");
            // カタカナの "ヴ" に変換されます。
            Test_VB("ゔ", "ヴ");
            // カタカナの "ヴ" は変換されません。
            Test_VB("ヴ", "ヴ");
            // "?" に変換されます。
            Test_VB("ゕゖゟ゠ヵヶヷヸヹヺヿ", new string('?', 11));
        }

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

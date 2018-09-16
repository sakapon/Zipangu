using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zipangu;

namespace NetUnitTest
{
    [TestClass]
    public class KanaConversionTest
    {
        const string VoiceableKatakanas = "ｳｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾊﾋﾌﾍﾎ";
        const string SemiVoiceableKatakanas = "ﾊﾋﾌﾍﾎ";

        [TestMethod]
        public void ToHiragana()
        {
            void Test(string value) => Assert.AreEqual(value.ToWideHiragana_VB(), value.ToHiragana());

            Test("");
            Test(KanaConversion.Asciis);
            Test(KanaConversion.HalfKatakanas);
            Test(string.Concat(VoiceableKatakanas.Select(c => $"{c}ﾞ")));
            Test(string.Concat(SemiVoiceableKatakanas.Select(c => $"{c}ﾞ")));
        }

        [TestMethod]
        public void ToHiragana_Null()
        {
            Assert.IsNull(default(string).ToHiragana());
        }

        [TestMethod]
        public void ToHiragana_Original()
        {
            var changed = Enumerable.Range(0, char.MaxValue + 1)
                .Select(i => new { i, before = (char)i, after = ((char)i).ToString().ToWideHiragana_VB().Single() })
                .Where(_ => _.before != _.after)
                .Where(_ => _.after != '？' || _.before == '?')
                .ToArray();

            foreach (var _ in changed)
                Console.WriteLine($"{_.i:D5}-{_.i:X4}: {_.before} > {_.after}");
        }
    }
}

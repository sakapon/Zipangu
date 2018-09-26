using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zipangu;

namespace NetUnitTest
{
    [TestClass]
    public class VBStringsTest
    {
        static string ToMessage1(char c) => $"({(int)c:D5}-{(int)c:X4}) {c}";
        static string ToMessage2(char c) => $"{c} ({(int)c:D5}-{(int)c:X4})";

        static void WriteChanged(VbStrConv mode)
        {
            // 他言語の文字は "?" に変換されます。
            var changed = EnumerableHelper.RangeChars(char.MinValue, char.MaxValue)
                .Select(c => new { before = c, after = Strings.StrConv(c.ToString(), mode).Single() })
                .Where(_ => _.before != _.after)
                .Where(_ => _.after != '?')
                .Select(_ => $"{ToMessage1(_.before)} > {ToMessage2(_.after)}")
                .ToArray();

            File.WriteAllLines($"VBStrings-{mode.ToString().Replace(", ", "")}.txt", changed, Encoding.UTF8);
        }

        static void WriteChanged_Wide(VbStrConv mode)
        {
            // 他言語の文字は "？" に変換されます。
            var changed = EnumerableHelper.RangeChars(char.MinValue, char.MaxValue)
                .Select(c => new { before = c, after = Strings.StrConv(c.ToString(), mode).Single() })
                .Where(_ => _.before != _.after)
                .Where(_ => _.after != '？' || _.before == '?')
                .Select(_ => $"{ToMessage1(_.before)} > {ToMessage2(_.after)}")
                .ToArray();

            File.WriteAllLines($"VBStrings-{mode.ToString().Replace(", ", "")}.txt", changed, Encoding.UTF8);
        }

        [TestMethod]
        public void Wide() => WriteChanged_Wide(VbStrConv.Wide);

        [TestMethod]
        public void Katakana() => WriteChanged(VbStrConv.Katakana);

        [TestMethod]
        public void Hiragana() => WriteChanged(VbStrConv.Hiragana);

        [TestMethod]
        public void WideKatakana() => WriteChanged_Wide(VbStrConv.Wide | VbStrConv.Katakana);

        [TestMethod]
        public void WideHiragana() => WriteChanged_Wide(VbStrConv.Wide | VbStrConv.Hiragana);
    }
}

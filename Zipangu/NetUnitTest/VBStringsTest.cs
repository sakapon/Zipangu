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

            File.WriteAllLines($"VBStrings-{mode}.txt", changed, Encoding.UTF8);
        }

        [TestMethod]
        public void Katakana() => WriteChanged(VbStrConv.Katakana);

        [TestMethod]
        public void Hiragana() => WriteChanged(VbStrConv.Hiragana);

        [TestMethod]
        public void ToWideHiragana_Original()
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

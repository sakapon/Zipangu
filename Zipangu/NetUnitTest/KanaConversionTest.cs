using System;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zipangu;

namespace NetUnitTest
{
    [TestClass]
    public class KanaConversionTest
    {
        [TestMethod]
        public void ToHiragana()
        {
            void Test(string value) => Assert.AreEqual(value.ToHiragana_VB(), value.ToHiragana());

            Test("");
            Test(KanaConversion.Asciis);
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
                .Select(i => new { i, before = (char)i, after = ((char)i).ToString().ToHiragana_VB().Single() })
                .Where(_ => _.before != _.after)
                .Where(_ => _.after != '？' || _.before == '?')
                .ToArray();

            foreach (var _ in changed)
                Console.WriteLine($"{_.i:D5}: {_.before} > {_.after}");
        }
    }

    public static class VBStringsHelper
    {
        public static string ToHiragana_VB(this string value) =>
            Strings.StrConv(value, VbStrConv.Wide | VbStrConv.Hiragana);
    }
}

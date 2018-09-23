using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetUnitTest
{
    [TestClass]
    public class VBStringsTest
    {
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

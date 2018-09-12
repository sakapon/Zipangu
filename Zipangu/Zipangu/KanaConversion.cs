using System;
using System.Linq;

namespace Zipangu
{
    public static class KanaConversion
    {
        internal static readonly string Asciis = string.Concat(Enumerable.Range(32, 95).Select(i => (char)i));

        public static string ToHiragana(this string value)
        {
            if (value == null) return null;

            throw new NotImplementedException();
        }
    }
}

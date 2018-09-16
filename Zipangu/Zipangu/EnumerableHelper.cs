using System;
using System.Collections.Generic;
using System.Linq;

namespace Zipangu
{
    static class EnumerableHelper
    {
        public static Dictionary<TKey, TValue> ZipToDictionary<TKey, TValue>(this IEnumerable<TKey> keys, IEnumerable<TValue> values) =>
            keys.Zip(values, (x, y) => new { x, y }).ToDictionary(_ => _.x, _ => _.y);

        public static string RangeChars(char start, char end) =>
            string.Concat(Enumerable.Range(start, end - start + 1).Select(i => (char)i));
    }
}

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

        internal static T ReplaceByMap<T>(this T value, IDictionary<T, T> map) =>
            map.ContainsKey(value) ? map[value] : value;

        internal static string ReplaceByMap(this string value, IDictionary<char, char> map) =>
            string.Concat(value.Select(c => c.ReplaceByMap(map)));
    }
}

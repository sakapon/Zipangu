using System;
using System.Collections.Generic;
using System.Linq;

namespace Zipangu
{
    /// <summary>
    /// ASCII 文字を変換するためのメソッドを提供します。
    /// </summary>
    public static class AsciiConversion
    {
        /// <summary>半角英数字記号 (ASCII 文字)。</summary>
        internal static readonly string Asciis = EnumerableHelper.RangeChars(' ', '~');
        /// <summary>全角英数字記号。</summary>
        internal static readonly string WideAsciis = "　" + EnumerableHelper.RangeChars('！', '～');

        static readonly IDictionary<char, char> WideMap = Asciis.ZipToDictionary(WideAsciis);
        static readonly IDictionary<char, char> NarrowMap = WideAsciis.ZipToDictionary(Asciis);

        internal static char ToWideAscii(char c) => WideMap.ContainsKey(c) ? WideMap[c] : c;
        internal static char ToNarrowAscii(char c) => NarrowMap.ContainsKey(c) ? NarrowMap[c] : c;

        /// <summary>
        /// 半角英数字記号 (ASCII 文字) を全角に変換します。
        /// </summary>
        /// <param name="value">変換対象の文字列。</param>
        /// <returns>変換後の文字列。</returns>
        public static string ToWideAscii(this string value) => value == null ? null : string.Concat(value.Select(ToWideAscii));

        /// <summary>
        /// 全角英数字記号を半角 (ASCII 文字) に変換します。
        /// </summary>
        /// <param name="value">変換対象の文字列。</param>
        /// <returns>変換後の文字列。</returns>
        public static string ToNarrowAscii(this string value) => value == null ? null : string.Concat(value.Select(ToNarrowAscii));
    }
}

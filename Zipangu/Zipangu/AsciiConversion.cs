using System;
using System.Collections.Generic;
using System.Linq;

namespace Zipangu
{
    /// <summary>
    /// ASCII 文字を変換するためのメソッドを提供します。
    /// <see cref="Microsoft.VisualBasic.Strings.StrConv"/> メソッドとの互換性は完全ではありません。
    /// </summary>
    public static class AsciiConversion
    {
        /// <summary>ASCII 文字。</summary>
        internal static readonly string Asciis = EnumerableHelper.RangeChars(' ', '~');
        /// <summary>全角 ASCII 文字。</summary>
        internal static readonly string WideAsciis = "　" + EnumerableHelper.RangeChars('！', '～');

        static readonly IDictionary<char, char> WideMap = Asciis.ZipToDictionary(WideAsciis);
        static readonly IDictionary<char, char> NarrowMap = WideAsciis.ZipToDictionary(Asciis);

        /// <summary>
        /// 半角 ASCII 文字 (英数字記号) を全角に変換します。
        /// </summary>
        /// <param name="value">変換対象の文字列。</param>
        /// <returns>変換後の文字列。</returns>
        public static string AsciiToWide(this string value) => value == null ? null : value.ReplaceByMap(WideMap);

        /// <summary>
        /// 全角 ASCII 文字 (英数字記号) を半角に変換します。
        /// </summary>
        /// <param name="value">変換対象の文字列。</param>
        /// <returns>変換後の文字列。</returns>
        public static string AsciiToNarrow(this string value) => value == null ? null : value.ReplaceByMap(NarrowMap);
    }
}

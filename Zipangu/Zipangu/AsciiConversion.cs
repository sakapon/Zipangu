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

        internal static char ToWide(char c) => WideMap.ContainsKey(c) ? WideMap[c] : c;
        internal static char ToNarrow(char c) => NarrowMap.ContainsKey(c) ? NarrowMap[c] : c;
    }
}

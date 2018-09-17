using System;
using Microsoft.VisualBasic;

namespace NetUnitTest
{
    public static class VBStringsHelper
    {
        public static string ToWide_VB(this string value) => Strings.StrConv(value, VbStrConv.Wide);
        public static string ToNarrow_VB(this string value) => Strings.StrConv(value, VbStrConv.Narrow);
        public static string ToKatakana_VB(this string value) => Strings.StrConv(value, VbStrConv.Katakana);
        public static string ToHiragana_VB(this string value) => Strings.StrConv(value, VbStrConv.Hiragana);

        public static string ToWideKatakana_VB(this string value) => Strings.StrConv(value, VbStrConv.Wide | VbStrConv.Katakana);
        public static string ToWideHiragana_VB(this string value) => Strings.StrConv(value, VbStrConv.Wide | VbStrConv.Hiragana);
    }
}

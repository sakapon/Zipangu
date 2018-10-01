using System;

namespace Zipangu
{
    /// <summary>
    /// 文字を変換するためのメソッドを提供します。
    /// <see cref="Microsoft.VisualBasic.Strings.StrConv"/> メソッドとの互換性は完全ではありません。
    /// </summary>
    public static class CharConversion
    {
        /// <summary>
        /// 変換の種類を指定して、文字を変換します。
        /// </summary>
        /// <param name="value">変換対象の文字列。</param>
        /// <param name="kana">かなの変換の種類。</param>
        /// <param name="ascii">ASCII 文字の変換の種類。</param>
        /// <returns>変換後の文字列。</returns>
        public static string Convert(this string value, KanaConv kana = KanaConv.None, AsciiConv ascii = AsciiConv.None)
        {
            if (!Enum.IsDefined(typeof(AsciiConv), ascii)) throw new ArgumentException("The value is not defined.", nameof(ascii));
            if (!Enum.IsDefined(typeof(KanaConv), kana)) throw new ArgumentException("The value is not defined.", nameof(kana));

            var current = value;

            if (ascii == AsciiConv.ToNarrow)
                current = current.AsciiToNarrow();
            else if (ascii == AsciiConv.ToWide)
                current = current.AsciiToWide();

            if (kana.HasFlag(KanaConv.KatakanaToHiragana))
                current = current.KatakanaToHiragana();
            if (kana.HasFlag(KanaConv.HalfKatakanaToHiragana))
                current = current.HalfKatakanaToHiragana();
            if (kana.HasFlag(KanaConv.HiraganaToKatakana))
                current = current.HiraganaToKatakana();
            if (kana.HasFlag(KanaConv.HalfKatakanaToKatakana))
                current = current.HalfKatakanaToKatakana();

            return current;
        }
    }

    /// <summary>
    /// ASCII 文字の変換の種類を示します。
    /// </summary>
    [Flags]
    public enum AsciiConv
    {
        /// <summary>なし。</summary>
        None,
        /// <summary>半角 ASCII 文字 (英数字記号) への変換。</summary>
        ToNarrow,
        /// <summary>全角 ASCII 文字 (英数字記号) への変換。</summary>
        ToWide,
    }

    /// <summary>
    /// かなの変換の種類を示します。
    /// </summary>
    [Flags]
    public enum KanaConv
    {
        /// <summary>なし。</summary>
        None,
        /// <summary>全角カタカナからひらがなへの変換。</summary>
        KatakanaToHiragana,
        /// <summary>半角カタカナからひらがなへの変換。</summary>
        HalfKatakanaToHiragana,
        /// <summary>全てのかなからひらがなへの変換。</summary>
        AllKanaToHiragana = KatakanaToHiragana | HalfKatakanaToHiragana,
        /// <summary>ひらがなから全角カタカナへの変換。</summary>
        HiraganaToKatakana = 4,
        /// <summary>半角カタカナから全角カタカナへの変換。</summary>
        HalfKatakanaToKatakana = 8,
        /// <summary>全てのかなから全角カタカナへの変換。</summary>
        AllKanaToKatakana = HiraganaToKatakana | HalfKatakanaToKatakana,
    }
}

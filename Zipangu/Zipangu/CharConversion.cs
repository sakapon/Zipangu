using System;

namespace Zipangu
{
    public static class CharConversion
    {
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

    [Flags]
    public enum AsciiConv
    {
        None,
        ToNarrow,
        ToWide,
    }

    [Flags]
    public enum KanaConv
    {
        None,
        KatakanaToHiragana,
        HalfKatakanaToHiragana,
        AllKanaToHiragana = KatakanaToHiragana | HalfKatakanaToHiragana,
        HiraganaToKatakana = 4,
        HalfKatakanaToKatakana = 8,
        AllKanaToKatakana = HiraganaToKatakana | HalfKatakanaToKatakana,
    }
}

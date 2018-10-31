using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Zipangu
{
    /// <summary>
    /// かなを変換するためのメソッドを提供します。
    /// <see cref="Microsoft.VisualBasic.Strings.StrConv"/> メソッドとの互換性は完全ではありません。
    /// </summary>
    public static class KanaConversion
    {
        /// <summary>ひらがな。</summary>
        internal static readonly string Hiraganas = EnumerableHelper.RangeChars('ぁ', 'ゖ') + "ゝゞ";
        /// <summary>カタカナ。</summary>
        internal static readonly string Katakanas = EnumerableHelper.RangeChars('ァ', 'ヶ') + "ヽヾ";
        /// <summary>半角カタカナ。</summary>
        internal static readonly string HalfKatakanas = EnumerableHelper.RangeChars('｡', 'ﾟ');

        /// <summary>半角カタカナに対応するひらがな。</summary>
        internal const string HiraganasByHalfKatakana = "。「」、・をぁぃぅぇぉゃゅょっーあいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわん゛゜";
        /// <summary>半角カタカナに対応するカタカナ。</summary>
        internal const string KatakanasByHalfKatakana = "。「」、・ヲァィゥェォャュョッーアイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワン゛゜";

        /// <summary>濁音となる半角カタカナ (ひらがな向け)。</summary>
        internal const string VoiceableHalfKatakanasForHiragana = "ｳｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾊﾋﾌﾍﾎ";
        /// <summary>濁音となる半角カタカナ (カタカナ向け)。</summary>
        internal const string VoiceableHalfKatakanasForKatakana = "ｦｳｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾊﾋﾌﾍﾎﾜ";
        /// <summary>濁音のひらがな。</summary>
        internal const string VoicedHiraganas = "ゔがぎぐげござじずぜぞだぢづでどばびぶべぼ";
        /// <summary>濁音のカタカナ。</summary>
        internal const string VoicedKatakanas = "ヺヴガギグゲゴザジズゼゾダヂヅデドバビブベボヷ";

        /// <summary>半濁音となる半角カタカナ。</summary>
        internal const string SemiVoiceableHalfKatakanas = "ﾊﾋﾌﾍﾎ";
        /// <summary>半濁音のひらがな。</summary>
        internal const string SemiVoicedHiraganas = "ぱぴぷぺぽ";
        /// <summary>半濁音のカタカナ。</summary>
        internal const string SemiVoicedKatakanas = "パピプペポ";

        static readonly IDictionary<char, char> HiraganaToKatakanaMap = Hiraganas.ZipToDictionary(Katakanas);
        static readonly IDictionary<char, char> KatakanaToHiraganaMap = Katakanas.ZipToDictionary(Hiraganas);
        static readonly IDictionary<char, char> HalfKatakanaToHiraganaMap = HalfKatakanas.ZipToDictionary(HiraganasByHalfKatakana);
        static readonly IDictionary<char, char> HalfKatakanaToKatakanaMap = HalfKatakanas.ZipToDictionary(KatakanasByHalfKatakana);

        static readonly IDictionary<string, string> VoicedHiraganaMap =
            VoiceableHalfKatakanasForHiragana.Zip(VoicedHiraganas, (x, y) => new { k = $"{x}ﾞ", v = y.ToString() })
                .Concat(SemiVoiceableHalfKatakanas.Zip(SemiVoicedHiraganas, (x, y) => new { k = $"{x}ﾟ", v = y.ToString() }))
                .ToDictionary(_ => _.k, _ => _.v);
        static readonly IDictionary<string, string> VoicedKatakanaMap =
            VoiceableHalfKatakanasForKatakana.Zip(VoicedKatakanas, (x, y) => new { k = $"{x}ﾞ", v = y.ToString() })
                .Concat(SemiVoiceableHalfKatakanas.Zip(SemiVoicedKatakanas, (x, y) => new { k = $"{x}ﾟ", v = y.ToString() }))
                .ToDictionary(_ => _.k, _ => _.v);

        static readonly Regex VoicedPattern = new Regex(".[ﾞﾟ]");

        /// <summary>
        /// ひらがなを全角カタカナに変換します。
        /// </summary>
        /// <param name="value">変換対象の文字列。</param>
        /// <returns>変換後の文字列。</returns>
        public static string HiraganaToKatakana(this string value) => value?.ReplaceByMap(HiraganaToKatakanaMap);

        /// <summary>
        /// 全角カタカナをひらがなに変換します。
        /// </summary>
        /// <param name="value">変換対象の文字列。</param>
        /// <returns>変換後の文字列。</returns>
        public static string KatakanaToHiragana(this string value) => value?.ReplaceByMap(KatakanaToHiraganaMap);

        /// <summary>
        /// 半角カタカナをひらがなに変換します。
        /// </summary>
        /// <param name="value">変換対象の文字列。</param>
        /// <returns>変換後の文字列。</returns>
        public static string HalfKatakanaToHiragana(this string value)
        {
            if (value == null) return null;
            var current = VoicedPattern.Replace(value, m => m.Value.ReplaceByMap(VoicedHiraganaMap));
            return current.ReplaceByMap(HalfKatakanaToHiraganaMap);
        }

        /// <summary>
        /// 半角カタカナを全角カタカナに変換します。
        /// </summary>
        /// <param name="value">変換対象の文字列。</param>
        /// <returns>変換後の文字列。</returns>
        public static string HalfKatakanaToKatakana(this string value)
        {
            if (value == null) return null;
            var current = VoicedPattern.Replace(value, m => m.Value.ReplaceByMap(VoicedKatakanaMap));
            return current.ReplaceByMap(HalfKatakanaToKatakanaMap);
        }
    }
}

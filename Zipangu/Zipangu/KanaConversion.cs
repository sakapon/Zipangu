using System;
using System.Linq;

namespace Zipangu
{
    public static class KanaConversion
    {
        /// <summary>半角英数字記号 (ASCII 文字)。</summary>
        internal static readonly string Asciis = string.Concat(Enumerable.Range(32, 95).Select(i => (char)i));
        /// <summary>全角英数字記号。<c>'\'</c> は変換されません。</summary>
        const string WideAsciis = @"　！＂＃＄％＆＇（）＊＋，－．／０１２３４５６７８９：；＜＝＞？＠ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ［\］＾＿｀ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚ｛｜｝～";

        /// <summary>半角カタカナ。</summary>
        internal static readonly string HalfKatakanas = string.Concat(Enumerable.Range('｡', 'ﾟ' - '｡' + 1).Select(i => (char)i));
        /// <summary>ひらがな。</summary>
        const string Hiraganas = "。「」、・をぁぃぅぇぉゃゅょっーあいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわん゛゜";

        /// <summary>半角カタカナの濁点。</summary>
        const char VoicedSoundMark = 'ﾞ';
        /// <summary>濁音となる半角カタカナ。</summary>
        const string VoiceableKatakanas = "ｳｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾊﾋﾌﾍﾎ";
        /// <summary>濁音のひらがな。</summary>
        const string VoicedHiraganas = "ヴがぎぐげござじずぜぞだぢづでどばびぶべぼ";

        /// <summary>半角カタカナの半濁点。</summary>
        const char SemiVoicedSoundMark = 'ﾟ';
        /// <summary>半濁音となる半角カタカナ。</summary>
        const string SemiVoiceableKatakanas = "ﾊﾋﾌﾍﾎ";
        /// <summary>半濁音のひらがな。</summary>
        const string SemiVoicedHiraganas = "ぱぴぷぺぽ";

        /// <summary>
        /// 全角カタカナおよび半角カタカナをひらがなに変換します。
        /// また、半角英数字記号 (ASCII 文字) を全角に変換します。
        /// <c>Microsoft.VisualBasic.Strings.StrConv(value, VbStrConv.Wide | VbStrConv.Hiragana)</c> と同等です。
        /// </summary>
        /// <param name="value">変換対象の文字列。</param>
        /// <returns>変換後の文字列。</returns>
        public static string ToHiragana(this string value)
        {
            if (value == null) return null;

            throw new NotImplementedException();
        }
    }
}

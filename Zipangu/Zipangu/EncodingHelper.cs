using System;
using System.Text;

namespace Zipangu
{
    /// <summary>
    /// 文字エンコーディングに関する機能を提供します。
    /// </summary>
    public static class EncodingHelper
    {
        /// <summary>
        /// Shift_JIS 形式のエンコーディングを取得します。
        /// </summary>
        public static Encoding ShiftJIS => _ShiftJIS.Value;
        static readonly Lazy<Encoding> _ShiftJIS = new Lazy<Encoding>(() => Encoding.GetEncoding("shift_jis"));

        /// <summary>
        /// ISO-2022-JP 形式のエンコーディングを取得します。
        /// </summary>
        public static Encoding ISO2022JP => _ISO2022JP.Value;
        static readonly Lazy<Encoding> _ISO2022JP = new Lazy<Encoding>(() => Encoding.GetEncoding("iso-2022-jp"));

        /// <summary>
        /// EUC-JP 形式のエンコーディングを取得します。
        /// </summary>
        public static Encoding EUCJP => _EUCJP.Value;
        static readonly Lazy<Encoding> _EUCJP = new Lazy<Encoding>(() => Encoding.GetEncoding("euc-jp"));

        static EncodingHelper()
        {
#if NETSTANDARD
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif
        }
    }
}

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
        public static Encoding ShiftJIS { get; }

        /// <summary>
        /// ISO-2022-JP 形式のエンコーディングを取得します。
        /// </summary>
        public static Encoding ISO2022JP { get; }

        /// <summary>
        /// EUC-JP 形式のエンコーディングを取得します。
        /// </summary>
        public static Encoding EUCJP { get; }

        static EncodingHelper()
        {
#if NETSTANDARD
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif
            ShiftJIS = Encoding.GetEncoding("shift_jis");
            ISO2022JP = Encoding.GetEncoding("iso-2022-jp");
            EUCJP = Encoding.GetEncoding("euc-jp");
        }
    }
}

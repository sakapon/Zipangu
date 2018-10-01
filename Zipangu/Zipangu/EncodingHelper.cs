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

        static EncodingHelper()
        {
#if NETSTANDARD
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif
            ShiftJIS = Encoding.GetEncoding("shift_jis");
        }
    }
}

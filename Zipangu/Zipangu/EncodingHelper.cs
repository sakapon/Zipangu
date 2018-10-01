using System;
using System.Text;

namespace Zipangu
{
    public static class EncodingHelper
    {
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

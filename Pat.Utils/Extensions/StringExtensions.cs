using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QVend.Ecr.Communication.TerminalMessages.Extensions
{
    public static class StringExtensions
    {
        public static byte[]? HexStringToByteArray(this string source)
        {
            if (source == null)
                return null;

            int NumberChars = source.Length;
            byte[] bytes = new byte[NumberChars / 2];

            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(source.Substring(i, 2), 16);

            return bytes;
        }
    }
}

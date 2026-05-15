using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QVend.Ecr.Communication.TerminalMessages.Extensions
{
    public static class ByteExtensions
    {
        public static byte[] GetValueBytes(this byte[] source)
        {
            byte[] result = TrimEnd(source);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(result);
            }

            return result;
        }

        public static byte[] GetValueBytesBcd(this byte[] source)
        {
            return TrimStart(source);
        }

        public static string? ToHexString(this byte[] bytes)
        {
            if (bytes == null)
                return null;
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private static byte[] TrimStart(byte[] array)
        {
            int firstIndex = Array.FindIndex(array, b => b != 0);

            if (firstIndex == -1)
            {
                return new byte[] { 0X00 };
            }

            byte[] result = new byte[array.Length - firstIndex];

            Array.Copy(array, firstIndex, result, 0, array.Length - firstIndex);

            return result;
        }

        private static byte[] TrimEnd(byte[] array)
        {
            int lastIndex = Array.FindLastIndex(array, b => b != 0);

            Array.Resize(ref array, lastIndex + 1);

            return array;
        }
    }
}

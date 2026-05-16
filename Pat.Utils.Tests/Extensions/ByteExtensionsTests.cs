using QVend.Ecr.Communication.TerminalMessages.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Pat.Utils.Tests.Extensions
{
    public class ByteExtensionsTests
    {
        [Fact]
        public void GetValueBytesTest()
        {
            byte[] source = { 1, 2, 3 };
            byte[] result = source.GetValueBytes();
            Assert.Equal(new byte[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void GetValueBytesBcdTest()
        {
            byte[] source = { 1, 2, 3 };
            byte[] result = source.GetValueBytesBcd();
            Assert.Equal(new byte[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void ToHexStringTest()
        {
            byte[] bytes = { 1, 2, 3 };
            string hexString = bytes.ToHexString();
            Assert.Equal("010203", hexString);
        }
    }
}

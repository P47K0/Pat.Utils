using QVend.Ecr.Communication.TerminalMessages.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pat.Utils.Tests.Extensions
{

    public class StringExtensionsTests
    {
        [Fact]
        public void HexStringToByteArray_NullInput_ShouldReturnNull()
        {
            string source = null;
            byte[] result = StringExtensions.HexStringToByteArray(source);
            Assert.Null(result);
        }

        [Fact]
        public void HexStringToByteArray_EmptyString_ShouldReturnEmptyArray()
        {
            string source = "";
            byte[] result = StringExtensions.HexStringToByteArray(source);
            Assert.Empty(result);
        }

        [Fact]
        public void HexStringToByteArray_ValidLowercaseHex_ShouldReturnCorrectBytes()
        {
            string source = "1a2b3c";
            byte[] expected = new byte[] { 0x1A, 0x2B, 0x3C };
            byte[] result = StringExtensions.HexStringToByteArray(source);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void HexStringToByteArray_ValidUppercaseHex_ShouldReturnCorrectBytes()
        {
            string source = "1A2B3C";
            byte[] expected = new byte[] { 0x1A, 0x2B, 0x3C };
            byte[] result = StringExtensions.HexStringToByteArray(source);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void HexStringToByteArray_InvalidHex_ShouldThrowArgumentException()
        {
            string source = "1G2H";
            Assert.Throws<FormatException>(() => StringExtensions.HexStringToByteArray(source));
        }

        [Fact]
        public void HexStringToByteArray_OddLengthInput_ShouldThrowArgumentException()
        {
            string source = "1A2B3C4";
            Assert.Throws<ArgumentOutOfRangeException>(() => StringExtensions.HexStringToByteArray(source));
        }
    }
}


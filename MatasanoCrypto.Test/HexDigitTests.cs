using System;
using FluentAssertions;
using MatasanoCrypto.Exceptions;
using NUnit.Framework;

namespace MatasanoCrypto.Test
{
    [TestFixture]
    class HexDigitTests
    {
        [TestCase('A')]
        [TestCase('F')]
        public void GivenValidHexChar_WhichIsUpperCase_AsCharReturnsSameCharAsLowerCase(char upperCaseHexChar)
        {
            var expectedHexChar = Char.ToLower(upperCaseHexChar);

            var hexDigit = new HexDigit(upperCaseHexChar);

            hexDigit.AsChar.Should().Be(expectedHexChar);
        }

        [TestCase('a')]
        [TestCase('f')]
        [TestCase('0')]
        [TestCase('9')]
        public void GivenValidHexChar_AsCharReturnsSameChar(char expectedHexChar)
        {
            var hexDigit = new HexDigit(expectedHexChar);

            hexDigit.AsChar.Should().Be(expectedHexChar);
        }

        [TestCase('0', 0x00)]
        [TestCase('1', 0x01)]
        [TestCase('9', 0x09)]
        [TestCase('a', 0x0a)]
        [TestCase('b', 0x0b)]
        [TestCase('f', 0x0f)]
        public void GivenValidHexChar_AsByteReturnsExpectedByte(char hexChar, byte expectedByte)
        {
            var hexDigit = new HexDigit(hexChar);

            hexDigit.AsByte.Should().Be(expectedByte);
        }

        [TestCase('g', "'g'")]
        [TestCase('h', "'h'")]
        [TestCase('z', "'z'")]
        [TestCase('-', "'-'")]
        public void GivenInvalidHexChar_ConstructorShouldThrow_InvalidHexDigitException(char invalidHexChar, string expectedError)
        {
            Action constructWithInvalidHexChar = () => new HexDigit(invalidHexChar);

            constructWithInvalidHexChar.ShouldThrow<InvalidHexDigitException>(expectedError);
        }

        [TestCase(0x00, '0')]
        [TestCase(0x0f, 'f')]
        public void GivenValidHexByte_AsCharReturnsExpectedChar(byte hexByte, char expectedHexChar)
        {
            var hexDigit = new HexDigit(hexByte);

            hexDigit.AsChar.Should().Be(expectedHexChar);
        }

        [TestCase(0x00)]
        [TestCase(0x0f)]
        public void GivenValidHexByte_AsByteReturnsExpectedByte(byte expectedHexByte)
        {
            var hexDigit = new HexDigit(expectedHexByte);

            hexDigit.AsByte.Should().Be(expectedHexByte);
        }

        [TestCase(0x10, "16")]
        [TestCase(0xf0, "240")]
        public void GivenInvalidHexByte_ConstructorShouldThrow_InvalidHexDigitException(byte invalidHexByte, string expectedError)
        {
            Action constructWithInvalidHexByte = () => new HexDigit(invalidHexByte);

            constructWithInvalidHexByte.ShouldThrow<InvalidHexDigitException>(expectedError);
        }

    }
}
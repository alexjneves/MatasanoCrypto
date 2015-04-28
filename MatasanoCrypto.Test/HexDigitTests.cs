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
        public void GivenValidHexDigit_WhichIsUpperCase_AsCharReturnsSameDigitAsLowerCase(char upperCaseHexDigit)
        {
            var expectedHexDigit = Char.ToLower(upperCaseHexDigit);

            var hexDigit = new HexDigit(upperCaseHexDigit);

            hexDigit.AsChar.Should().Be(expectedHexDigit);
        }

        [TestCase('a')]
        [TestCase('f')]
        [TestCase('0')]
        [TestCase('9')]
        public void GivenValidHexDigit_AsCharReturnsSameDigit(char expectedHexDigit)
        {
            var hexDigit = new HexDigit(expectedHexDigit);

            hexDigit.AsChar.Should().Be(expectedHexDigit);
        }

        [TestCase('0', 0x00)]
        [TestCase('1', 0x01)]
        [TestCase('9', 0x09)]
        [TestCase('a', 0x0a)]
        [TestCase('b', 0x0b)]
        [TestCase('f', 0x0f)]
        public void GivenValidHexDigit_AsByteReturnsExpectedByte(char digit, byte expectedByte)
        {
            var hexDigit = new HexDigit(digit);

            hexDigit.AsByte.Should().Be(expectedByte);
        }

        [TestCase('g')]
        [TestCase('h')]
        [TestCase('z')]
        [TestCase('-')]
        public void GivenInvalidHexDigit_ConstructorShouldThrow_InvalidHexDigitException(char invalidHexDigit)
        {
            Action constructWithInvalidHexDigit = () => new HexDigit(invalidHexDigit);

            constructWithInvalidHexDigit.ShouldThrow<InvalidHexDigitException>();
        }

    }
}
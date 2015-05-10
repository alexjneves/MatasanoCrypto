using System;
using FluentAssertions;
using MatasanoCrypto.Exceptions;
using NUnit.Framework;

namespace MatasanoCrypto.Test
{
    [TestFixture]
    internal sealed class HexStringTests
    {
        [TestCase("1AbC")]
        [TestCase("aF")]
        [TestCase("Af")]
        public void GivenValidHex_WithUpperCaseCharacters_HexStringStoresItAsLowerCase(string upperCaseHex)
        {
            var expectedHex = upperCaseHex.ToLower();

            var hexString = new HexString(upperCaseHex);

            hexString.Hex.Should().Be(expectedHex);
        }

        [TestCase("aa")]
        [TestCase("1ef3")]
        [TestCase("af09")]
        public void GivenValidHex_WithAllLowerCaseCharacters_HexStringStoresSameHex(string expectedHex)
        {
            var hexString = new HexString(expectedHex);

            hexString.Hex.Should().Be(expectedHex);
        }

        [Test]
        public void GivenValidHex_IndexOperator_ReturnsExpectedHexDigits()
        {
            const string Hex = "0c9f";

            var expectedHexDigits = new HexDigit[]
            {
                new HexDigit('0'),
                new HexDigit('c'), 
                new HexDigit('9'), 
                new HexDigit('f'), 
            };

            var hexString = new HexString(Hex);

            for (var i = 0; i < Hex.Length; ++i)
            {
                var expectedDigit = expectedHexDigits[i];
                var actualDigit = hexString[i];

                expectedDigit.AsChar.Should().Be(actualDigit.AsChar);
                expectedDigit.AsByte.Should().Be(actualDigit.AsByte);
            }
        }

        [TestCase("")]
        [TestCase("abc")]
        [TestCase("zz")]
        public void GivenInvalidHex_ConstructorShouldThrow_InvalidHexStringException(string invalidHex)
        {
            Action constructWithInvalidHex = () => new HexString(invalidHex);

            constructWithInvalidHex.ShouldThrow<InvalidHexStringException>();
        }

        [Test]
        public void GivenValidHexDigitArray_ConstructsExpectedHexString()
        {
            var hexDigits = new HexDigit[]
            {
                new HexDigit('0'),
                new HexDigit('f'), 
            };

            const string ExpectedHex = "0f";

            var hexString = new HexString(hexDigits);

            hexString.Hex.Should().Be(ExpectedHex);
        }

        [Test]
        public void GivenInvalidHexDigitArray_ConstructorShouldThrow_InvalidHexStringException()
        {
            var hexDigits = new HexDigit[] { new HexDigit('0') };

            Action constructWithInvalidHexDigitArray = () => new HexString(hexDigits);

            constructWithInvalidHexDigitArray.ShouldThrow<InvalidHexStringException>();
        }

    }
}
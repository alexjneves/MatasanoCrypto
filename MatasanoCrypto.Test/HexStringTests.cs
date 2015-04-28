using System;
using FluentAssertions;
using MatasanoCrypto.Exceptions;
using NUnit.Framework;

namespace MatasanoCrypto.Test
{
    [TestFixture]
    class HexStringTests
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

        [TestCase("")]
        [TestCase("abc")]
        [TestCase("zz")]
        public void GivenInvalidHex_ConstructorShouldThrow_InvalidHexStringException(string invalidHex)
        {
            Action constructWithInvalidHex = () => new HexString(invalidHex);

            constructWithInvalidHex.ShouldThrow<InvalidHexStringException>();
        }

    }
}
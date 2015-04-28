using FluentAssertions;
using NUnit.Framework;

namespace MatasanoCrypto.Test
{
    [TestFixture]
    public class HexToBytesConverterTests
    {
        [Test]
        public void GivenHexString_WithUpperCaseDigits_ConvertsToExpectedByteArray()
        {
            var hex = new HexString("0CF9");
            var expected = new byte[] { 0x0C, 0xF9 };

            var hexToBytes = new HexToBytesConverter(hex);

            hexToBytes.Bytes.Should().Equal(expected);
        }

        [Test]
        public void GivenHexString_WithLowerCaseDigits_ConvertsToExpectedByteArray()
        {
            var hex = new HexString("0cf9");
            var expected = new byte[] { 0x0C, 0xF9 };

            var hexToBytes = new HexToBytesConverter(hex);

            hexToBytes.Bytes.Should().Equal(expected);
        }

        [Test]
        public void GivenHexString_WithMixedCaseDigits_ConvertsToExpectedByteArray()
        {
            var hex = new HexString("0cF9");
            var expected = new byte[] { 0x0C, 0xF9 };

            var hexToBytes = new HexToBytesConverter(hex);

            hexToBytes.Bytes.Should().Equal(expected);
        }

    }
}

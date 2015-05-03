using FluentAssertions;
using NUnit.Framework;

namespace MatasanoCrypto.Test
{
    [TestFixture]
    public class BytesToHexConverterTests
    {
        [Test]
        public void GivenValidByteArray_ConvertsToExpectedHexString()
        {
            var bytes = new byte[] { 0x0C, 0xF9 };
            const string Expected = "0cf9";

            var bytesToHex = new BytesToHexConverter(bytes);

            bytesToHex.HexString.Hex.Should().Be(Expected);
        }

    }
}
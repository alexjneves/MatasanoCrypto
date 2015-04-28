using FluentAssertions;
using NUnit.Framework;

namespace MatasanoCrypto.Test
{
    [TestFixture]
    class HexToBase64EncoderTests
    {
        [Test]
        public void GivenHexString_WhichRequiresNoPadding_EncodingProducesExpectedStringWithNoPadding()
        {
            var hex = new HexString(
                "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d");

            const string ExpectedBase64 = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t";

            var encoder = new HexToBase64Encoder(hex);

            encoder.Base64.Should().Be(ExpectedBase64);
        }

        [Test]
        public void GivenHexString_WhichRequiresOnePadding_EncodingProducesExpectedStringWithOnePadding()
        {
            var hex = new HexString("49AB");
            const string ExpectedBase64 = "Sas=";

            var encoder = new HexToBase64Encoder(hex);

            encoder.Base64.Should().Be(ExpectedBase64);
        }

        [Test]
        public void GivenHexString_WhichRequiresTwoPadding_EncodingProducesExpectedStringWithTwoPadding()
        {
            var hex = new HexString("49");
            const string ExpectedBase64 = "SQ==";

            var encoder = new HexToBase64Encoder(hex);

            encoder.Base64.Should().Be(ExpectedBase64);
        }

    }
}
using System;
using FluentAssertions;
using MatasanoCrypto.Exceptions;
using NUnit.Framework;

namespace MatasanoCrypto.Test
{
    [TestFixture]
    internal sealed class FixedXorTests
    {
        [Test]
        public void GivenTwoHexStrings_OfEqualLengths_FixedXorProducesExpectedResult()
        {
            var first = new HexString("1c0111001f010100061a024b53535009181c");
            var second = new HexString("686974207468652062756c6c277320657965");
            var expected = new HexString("746865206b696420646f6e277420706c6179");

            var fixedXor = new FixedXor(first, second);

            fixedXor.Result.Hex.Should().Be(expected.Hex);
        }

        [Test]
        public void GivenTwoHexStrings_OfDifferentLengths_ConstructorShouldThrowFixedXorException()
        {
            var first = new HexString("00");
            var second = new HexString("0000");

            Action fixedXor = () => new FixedXor(first, second);

            fixedXor.ShouldThrow<FixedXorException>();
        }
    }
}
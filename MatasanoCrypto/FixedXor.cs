using MatasanoCrypto.Exceptions;

namespace MatasanoCrypto
{
    public sealed class FixedXor
    {
        private readonly HexString _result;

        public HexString Result { get { return _result; } }

        public FixedXor(HexString first, HexString second)
        {
            if (first.Hex.Length != second.Hex.Length)
            {
                throw new FixedXorException("String lengths are not equal");
            }

            var firstByteArray = new HexToBytesConverter(first);
            var secondByteArray = new HexToBytesConverter(second);

            var length = firstByteArray.Bytes.Length;

            var xorBytes = new byte[length];

            for (var i = 0; i < length; ++i)
            {
                xorBytes[i] = (byte) (firstByteArray.Bytes[i] ^ secondByteArray.Bytes[i]);
            }

            _result = new BytesToHexConverter(xorBytes).HexString;
        }

    }
}

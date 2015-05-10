using System.Collections.Generic;

namespace MatasanoCrypto
{
    public sealed class BytesToHexConverter
    {
        private readonly HexString _hexString;

        public HexString HexString { get { return _hexString; } }

        public BytesToHexConverter(IReadOnlyList<byte> bytes)
        {
            _hexString = BytesToHex(bytes);
        }

        private static HexString BytesToHex(IReadOnlyList<byte> bytes)
        {
            var hexDigits = new HexDigit[bytes.Count << 1];

            for (var i = 0; i < bytes.Count; ++i)
            {
                var hexByte = bytes[i];

                var firstNibble = (byte) (hexByte & 0x0f);
                var secondNibble = (byte) (hexByte >> 4);

                var index = i * 2;

                hexDigits[index] = new HexDigit(secondNibble);
                hexDigits[index + 1] = new HexDigit(firstNibble);
            }

            return new HexString(hexDigits);
        }
    }
}

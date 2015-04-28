namespace MatasanoCrypto
{
    public class HexToBytesConverter
    {
        private readonly byte[] _bytes;

        public byte[] Bytes { get { return _bytes; } }

        public HexToBytesConverter(HexString hexString)
        {
            _bytes = HexToByteArray(hexString);
        }

        private static byte[] HexToByteArray(HexString hexString)
        {
            var hex = hexString.Hex;

            var bytes = new byte[hex.Length / 2];

            for (var i = 0; i < bytes.Length; ++i)
            {
                var index = i * 2;

                var first = hexString[index].AsByte;
                var second = hexString[index + 1].AsByte;

                var final = (byte) (first << 0x04 | second);

                bytes[i] = final;
            }

            return bytes;
        }

    }
}
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatasanoCrypto
{
    public class HexToBase64Encoder
    {
        private const string Base64Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        private const int SixBitMask = 0x3F;

        private readonly string _base64;

        public string Base64 { get { return _base64; } }

        public HexToBase64Encoder(HexString hex)
        {
            var bytes = new HexToBytesConverter(hex).Bytes;

            _base64 = Encode(bytes.ToList());
        }

        private static string Encode(IList<byte> bytes)
        {
            var padding = "";

            while (bytes.Count % 3 != 0)
            {
                padding += "=";
                bytes.Add(0);
            }

            var result = new StringBuilder();

            for (var i = 0; i < bytes.Count; i += 3)
            {
                var combined = 0;
                combined += bytes[i] << 16;
                combined += bytes[i + 1] << 8;
                combined += bytes[i + 2];

                var byte1 = (combined >> 18) & SixBitMask;
                var byte2 = (combined >> 12) & SixBitMask;
                var byte3 = (combined >> 6) & SixBitMask;
                var byte4 = combined & SixBitMask;

                result.Append(Base64Characters[byte1]);
                result.Append(Base64Characters[byte2]);
                result.Append(Base64Characters[byte3]); 
                result.Append(Base64Characters[byte4]);
            }

            return result.ToString().Substring(0, result.Length - padding.Length) + padding;
        }

    }
}
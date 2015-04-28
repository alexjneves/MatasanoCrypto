using System;
using MatasanoCrypto.Exceptions;

namespace MatasanoCrypto
{
    public class HexDigit
    {
        private readonly char _asChar;
        private readonly byte _asByte;

        public char AsChar { get { return _asChar; } }
        public byte AsByte { get { return _asByte; } }

        public HexDigit(char hexDigit)
        {
            _asChar = Char.ToLower(hexDigit);

            if (_asChar >= '0' && _asChar <= '9')
            {
                _asByte = Convert.ToByte(_asChar - '0');
            }
            else if (_asChar >= 'a' && _asChar <= 'f')
            {
                _asByte = Convert.ToByte(_asChar - 'a' + 10);
            }
            else
            {
                throw new InvalidHexDigitException(_asChar);
            }
        }
    }
}
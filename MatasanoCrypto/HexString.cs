﻿using MatasanoCrypto.Exceptions;

namespace MatasanoCrypto
{
    public sealed class HexString
    {
        private readonly HexDigit[] _digits;
        private readonly string _hex;

        public string Hex { get { return _hex; } }

        public HexString(string hex)
        {
            _hex = hex.ToLower();
            _digits = new HexDigit[_hex.Length];

            if (string.IsNullOrEmpty(_hex) || (_hex.Length & 1) != 0)
            {
                throw new InvalidHexStringException();
            }

            for (var i = 0; i < _hex.Length; ++i)
            {
                try
                {
                    _digits[i] = new HexDigit(_hex[i]);
                }
                catch (InvalidHexDigitException e)
                {
                    throw new InvalidHexStringException(e);
                }
            }
        }

        public HexString(HexDigit[] hexDigits)
        {
            if ((hexDigits.Length & 1) != 0)
            {
                throw new InvalidHexStringException();
            }

            var hexChars = new char[hexDigits.Length];

            for (var i = 0; i < hexDigits.Length; ++i)
            {
                hexChars[i] = hexDigits[i].AsChar;
            }

            _hex = new string(hexChars);
            _digits = hexDigits;
        }

        public HexDigit this[int i]
        {
            get { return _digits[i]; }
        }
    }
}
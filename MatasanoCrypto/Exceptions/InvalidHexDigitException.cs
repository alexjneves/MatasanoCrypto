using System;

namespace MatasanoCrypto.Exceptions
{
    public class InvalidHexDigitException : Exception
    {
        public InvalidHexDigitException(char invalidChar) :
            base(string.Format("'{0}'", invalidChar))
        {
        }
    }
}
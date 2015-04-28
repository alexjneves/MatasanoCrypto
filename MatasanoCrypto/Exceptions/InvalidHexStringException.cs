using System;

namespace MatasanoCrypto.Exceptions
{
    public class InvalidHexStringException : Exception
    {
        public InvalidHexStringException()
        {
        }
        
        public InvalidHexStringException(Exception innerException) : base("Invalid Hex String", innerException)
        {
        }
    }
}
using System;

namespace MatasanoCrypto.Exceptions
{
    public sealed class InvalidHexStringException : Exception
    {
        public InvalidHexStringException()
        {
        }
        
        public InvalidHexStringException(Exception innerException) : base("Invalid Hex String", innerException)
        {
        }
    }
}
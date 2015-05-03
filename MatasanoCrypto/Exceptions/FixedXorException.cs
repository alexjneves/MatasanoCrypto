using System;

namespace MatasanoCrypto.Exceptions
{
    public class FixedXorException : Exception
    {
        public FixedXorException(string message) : base(message)
        {
        }
    }
}
using System;

namespace MatasanoCrypto.Exceptions
{
    public sealed class FixedXorException : Exception
    {
        public FixedXorException(string message) : base(message)
        {
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace Anabi.Common.Exceptions
{
    public class AnabiValidationException : Exception
    {
        public AnabiValidationException()
        {
        }

        public AnabiValidationException(string message) : base(message)
        {
        }

        public AnabiValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AnabiValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Anabi.Domain.Exceptions
{
    public class DomainModelValidationException : Exception
    {
        public List<string> Errors { get; set; }

        

        public DomainModelValidationException()
        {
        }

        public DomainModelValidationException(string message) : base(message)
        {
        }

        public DomainModelValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainModelValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        
    }
}

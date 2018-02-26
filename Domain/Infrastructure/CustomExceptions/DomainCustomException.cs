using System;
using System.Runtime.Serialization;

namespace Domain.Infrastructure.CustomExceptions
{
    public class DomainCustomException : Exception
    {
        public DomainCustomException()
        {
        }

        public DomainCustomException(string message) : base(message)
        {
        }

        public DomainCustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainCustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

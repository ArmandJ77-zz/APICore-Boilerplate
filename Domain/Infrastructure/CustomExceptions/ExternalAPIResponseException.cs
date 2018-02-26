using System;
using System.Runtime.Serialization;

namespace Domain.Infrastructure.CustomExceptions
{
    public class ExternalAPIResponseException : Exception
    {
        public ExternalAPIResponseException()
        {
        }

        public ExternalAPIResponseException(string message) : base(message)
        {
        }

        public ExternalAPIResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExternalAPIResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

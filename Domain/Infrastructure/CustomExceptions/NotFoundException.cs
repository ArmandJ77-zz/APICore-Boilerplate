using System;

namespace Domain.Infrastructure.CustomExceptions
{
    public class NotFoundException : Exception
    {
        //private const string msg = "The requested resource could not be found";

        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

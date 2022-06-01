using System;

namespace Poodle.Services.Exceptions
{
    public class UnauthorizedOperationException : ApplicationException
    {
        public UnauthorizedOperationException()
        {
        }

        public UnauthorizedOperationException(string message) : base(message)
        {
        }
    }
}

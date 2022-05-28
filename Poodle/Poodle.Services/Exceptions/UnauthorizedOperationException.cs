using System;

namespace Poodle.API.Exceptions
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

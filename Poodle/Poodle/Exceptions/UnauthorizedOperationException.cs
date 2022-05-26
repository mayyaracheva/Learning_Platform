using System;

namespace Poodle.Exceptions
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

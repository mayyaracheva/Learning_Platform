using System;

namespace Poodle.API.Exceptions
{
	public class DuplicateEntityException : ApplicationException
    {
        public DuplicateEntityException()
        {
        }

        public DuplicateEntityException(string message) : base(message)
        {
        }
    }
}

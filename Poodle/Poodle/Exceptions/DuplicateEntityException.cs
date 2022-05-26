using System;

namespace Poodle.Exceptions
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

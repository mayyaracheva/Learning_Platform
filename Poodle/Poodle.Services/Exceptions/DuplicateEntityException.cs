using System;

namespace Poodle.Services.Exceptions
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

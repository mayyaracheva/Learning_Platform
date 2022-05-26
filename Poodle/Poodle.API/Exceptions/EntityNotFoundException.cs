using System;

namespace Poodle.API.Exceptions
{
	public class EntityNotFoundException : ApplicationException
	{
		public EntityNotFoundException()
		{
		}

		public EntityNotFoundException(string message)
			: base(message)
		{
		}
	}
}

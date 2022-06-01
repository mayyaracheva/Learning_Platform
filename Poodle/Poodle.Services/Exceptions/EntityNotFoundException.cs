using System;

namespace Poodle.Services.Exceptions
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

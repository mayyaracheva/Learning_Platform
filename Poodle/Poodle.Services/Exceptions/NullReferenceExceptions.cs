using System;

namespace Poodle.Services.Exceptions
{
    public class NullReferenceExceptions : ApplicationException
    {
		public NullReferenceExceptions()
		{

		}

		public NullReferenceExceptions(string message)
			: base(message)
		{

		}
	}
}

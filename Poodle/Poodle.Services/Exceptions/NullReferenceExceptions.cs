using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

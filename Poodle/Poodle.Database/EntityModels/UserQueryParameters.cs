using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Data.EntityModels
{
    public class UserQueryParameters
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }		
		public string Email { get; set; }
		//search for students currently not enrolled in the current private course
		public Course Course { get; set; }

		public bool HasQueryParameters
		{
			get
			{
				return FirstName is not null & Email is not null & LastName is not null & Course is not null;
			}
		}
	}
}

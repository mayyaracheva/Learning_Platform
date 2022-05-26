using System.Collections.Generic;

namespace Poodle.Database.EntityModels
{
	public class Role
	{
		public int Id { get; set; }
		public string Name { get; set; }

		//Navigation Properties
		//one-to-many relationship; 1 user role can have many users, one user can have only 1 role
		public ICollection<User> Users { get; set; }

	}
}

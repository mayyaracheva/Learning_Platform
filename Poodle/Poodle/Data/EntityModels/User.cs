using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Poodle.Data.EntityModels
{
	public class User
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		//Navigation properties
		//foreign key, user can have one role
		public int RoleId { get; set; }
		public Role Role { get; set; }

		//one to one relationship - one user can have one profile photo
		
		public int? ImageId { get; set; }
		public Image Image { get; set; }

		public ICollection<Course> Courses { get; set; }

	}
}

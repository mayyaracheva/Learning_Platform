using System.Collections.Generic;

namespace Poodle.Data.EntityModels
{
	public class Course
	{
		public int Id { get; set; } 
		public string Title { get; set; }
		public string Description { get; set; }

		public int TypeId { get; set; }
		public Type Type { get; set; }

		//a course can have many sections and many users
		public ICollection<Section> Sections { get; set; }
		public ICollection<User> Users { get; set; }

	}
}

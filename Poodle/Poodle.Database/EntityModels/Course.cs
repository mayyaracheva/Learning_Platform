using System.Collections.Generic;

namespace Poodle.Database.EntityModels
{
	public class Course
	{
		public int Id { get; set; } 
		public string Title { get; set; }
		public string Description { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }

		//a course can have many sections and many users
		public ICollection<Section> Sections { get; set; }
		public ICollection<User> Users { get; set; }

	}
}

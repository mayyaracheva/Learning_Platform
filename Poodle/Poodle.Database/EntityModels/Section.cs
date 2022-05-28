using System;

namespace Poodle.Data.EntityModels
{
	public class Section
	{
		public int Id { get; set; }
		public string Title { get; set; }
		//public int Order { get; set; }		
		//public DateTime ActiveBy { get; set; }
		//public bool IsActive { get; set; }
		public int CourseId { get; set; }
		public Course Course { get; set; }

	}
}

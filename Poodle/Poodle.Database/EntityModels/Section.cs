﻿namespace Poodle.Database.EntityModels
{
	public class Section
	{
		public int Id { get; set; }
		public string Title { get; set; }		

		public int CourseId { get; set; }
		public Course Course { get; set; }

	}
}
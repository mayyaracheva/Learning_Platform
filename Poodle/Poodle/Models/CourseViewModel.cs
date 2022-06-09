using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using System.Collections.Generic;

namespace Poodle.Web.Models
{
	public class CourseViewModel
	{
		public CourseViewModel()
		{

		}
		public CourseViewModel(Course course)
		{
			this.Title = course.Title;
			this.Description = course.Description;
			this.UsersCount = course.Users.Count;
		}
		public string Title { get; set; }
		public string Description { get; set; }

		public int UsersCount { get; set; }
	}
}

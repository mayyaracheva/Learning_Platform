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
			this.CourseId = course.Id;
			this.Title = course.Title;
			this.Description = course.Description;
			this.UsersCount = course.Users.Count;
			this.PhotoURL = course.PhotoURL;
		}

		public int CourseId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public string ShortDescription 
			=> this.Description?.Length > 80
			? this.Description?.Substring(0,80) + "..."
			: this.Description;
		public string PhotoURL { get; set; }
		public int UsersCount { get; set; }
	}
}

using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;

namespace Poodle.Web.Models
{
	public class CourseViewModel : CourseCreateDTO
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
			this.CategoryId = course.CategoryId;
		}

		public int CourseId { get; set; }
		public string ShortDescription 
			=> this.Description?.Length > 80
			? this.Description?.Substring(0,80) + "..."
			: this.Description;
		public int UsersCount { get; set; }

	}
}

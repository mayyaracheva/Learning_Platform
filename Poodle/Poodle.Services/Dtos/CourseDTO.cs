
using Poodle.Data.EntityModels;

namespace Poodle.Services.Dtos
{
	public  class CourseDTO
	{
		public CourseDTO()
		{

		}
		public CourseDTO(Course course)
		{
			this.Title = course.Title;
			this.Description = course.Description;
			this.PhotoURL = course.PhotoURL;
			this.CategoryId = course.CategoryId;
		}

		public string Title { get; set; }
		public string Description { get; set; }
		public int CategoryId { get; set; }
		public string PhotoURL { get; set; }
	}
}

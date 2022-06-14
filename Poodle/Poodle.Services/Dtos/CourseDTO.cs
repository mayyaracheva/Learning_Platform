
using Poodle.Data.EntityModels;
using System.ComponentModel.DataAnnotations;

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

		[Required]
		public string Title { get; set; }
		[Required]
		public string Description { get; set; }
		public int CategoryId { get; set; }
		[Required]
		public string PhotoURL { get; set; }
	}
}

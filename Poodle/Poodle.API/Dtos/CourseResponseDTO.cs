using Poodle.Data.EntityModels;

namespace Poodle.API.Dtos
{
	public class CourseResponseDTO
	{
		public CourseResponseDTO()
		{

		}
		public CourseResponseDTO(Course course)
		{
			this.Title = course.Title;
			this.Description = course.Description;
		}
		public string Title { get; set; }
		public string Description { get; set; }

	}
}

using Poodle.Services.Dtos;

namespace Poodle.Web.Models
{
	public class PublicCourseViewModel
	{
		public PublicCourseViewModel()
		{

		}
		public PublicCourseViewModel(CourseResponseDTO dto)
		{
			this.Title = dto.Title;
			this.Description = dto.Description;
		}
		public string Title { get; set; }
		public string Description { get; set; }

    }
}

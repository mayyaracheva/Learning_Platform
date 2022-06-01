using Poodle.Services.Dtos;
using Poodle.Data.EntityModels;

namespace Poodle.Services.Mappers
{
	public class CourseMapper
	{
		public Course ConvertToModel(CourseResponseDTO dto)
		{
			var course = new Course();
			course.Title = dto.Title;
			course.Description = dto.Description;

			return course;
		}
	}
}

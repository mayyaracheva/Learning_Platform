using Poodle.API.Dtos;
using Poodle.Data.EntityModels;

namespace Poodle.API.Mappers
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

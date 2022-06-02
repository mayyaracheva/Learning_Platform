using Poodle.Services.Dtos;
using Poodle.Data.EntityModels;
using System;

namespace Poodle.Services.Mappers
{
	public class CourseMapper
	{
		public Course Convert(CourseCreateDTO dto)
		{
			var course = new Course();
			course.Title = dto.Title;
			course.Description = dto.Description;
			course.CategoryId = dto.CategoryId;
			course.CreatedOn = DateTime.Now;

			return course;
		}
		public Course ConvertToModel(CourseResponseDTO dto)
		{
			var course = new Course();
			course.Title = dto.Title;
			course.Description = dto.Description;

			return course;
		}

		public CourseResponseDTO ConvertToDTO(Course course)
		{
			var dto = new CourseResponseDTO();
			dto.Title = course.Title;
			dto.Description = course.Description;

			return dto;
		}
	}
}

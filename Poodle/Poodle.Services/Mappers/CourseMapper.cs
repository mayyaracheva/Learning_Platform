using Poodle.Services.Dtos;
using Poodle.Data.EntityModels;
using System;

namespace Poodle.Services.Mappers
{
	public class CourseMapper
	{
		public Course Convert(CourseDTO dto)
		{
			var course = new Course();
			course.Title = dto.Title;
			course.Description = dto.Description;
			course.CategoryId = dto.CategoryId;
			course.PhotoURL = dto.PhotoURL;

			return course;
		}
	}
}

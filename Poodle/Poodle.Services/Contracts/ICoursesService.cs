using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
	public interface ICoursesService
	{
		Task<List<Course>> GetAsync();
		CourseResponseDTO Get(int id);
		Task<List<Course>> Get(CourseQueryParameters filterParameters);
		Task<Course> CreateAsync(CourseCreateDTO course, User user);
		Task<Course> UpdateAsync(int id, Course course);
		Task<Course> DeleteAsync(int id);

	}
}

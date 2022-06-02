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

		//Task<List<Course>> Get(CourseQueryParameters filterParameters);
		Task<Course> CreateAsync(CourseDTO course, User user);
		Task<Course> UpdateAsync(int id, User user, CourseDTO dto);
		Task<Course> DeleteAsync(int id);

	}
}

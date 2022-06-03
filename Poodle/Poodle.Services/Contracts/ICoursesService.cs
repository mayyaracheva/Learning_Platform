using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
	public interface ICoursesService
	{
		Task<dynamic> GetAsync(User user);
		CourseResponseDTO Get(int id, User user);

		//Task<List<Course>> Get(CourseQueryParameters filterParameters);
		Task<Course> CreateAsync(CourseDTO course, User user);
		Task<Course> UpdateAsync(int id, User user, CourseDTO dto);
		Task<Course> DeleteAsync(int id, User user);

	}
}

using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
	public interface ICoursesService
	{
		Task<List<CourseResponseDTO>> GetAsync();
		Course GetById(int id);
		Task<IEnumerable<Course>> Get(CourseQueryParameters filterParameters);
		Task<Course> CreateAsync(Course course);
		Task<Course> UpdateAsync(int id, Course course);
		Task<Course> DeleteAsync(int id);

	}
}

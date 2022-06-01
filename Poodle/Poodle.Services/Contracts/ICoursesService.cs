using Poodle.Data.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
	public interface ICoursesService
	{
		Task<IEnumerable<Course>> GetAsync();
		Course GetById(int id);
		Task<IEnumerable<Course>> Get(CourseQueryParameters filterParameters);
		Task<Course> CreateAsync(Course course);
		Task<Course> UpdateAsync(int id, Course course);
		Task<Course> DeleteAsync(int id);

	}
}

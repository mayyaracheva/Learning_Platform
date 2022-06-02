using Poodle.Data.EntityModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Repositories.Contracts
{
	public interface ICoursesRepository
	{
		IQueryable<Course> GetAll();
		Course Get(int id);
		Course GetByTitle(string title);
		IQueryable<Course> Get(CourseQueryParameters filterParameters);
		Task<Course> CreateAsync(Course course);
		Task<Course> UpdateAsync(int id, Course course);
		Task<Course> DeleteAsync(int id);
	}
}

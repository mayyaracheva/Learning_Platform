using Poodle.Data.EntityModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Repositories.Contracts
{
	public interface ICoursesRepository
	{
		IQueryable<Course> GetAll();
		IQueryable<Course> Get(int id);
		IQueryable<Course> GetByTitle(string title);
		IQueryable<Course> Get(CourseQueryParameters filterParameters);
		Task<Course> CreateAsync(Course course);
		Task<Course> UpdateAsync(Course courseToUpdate, Course course);
		Task<Course> DeleteAsync(int id, Course course);

		Task EnrollInPublicCourse(User user, Course course);
	}
}

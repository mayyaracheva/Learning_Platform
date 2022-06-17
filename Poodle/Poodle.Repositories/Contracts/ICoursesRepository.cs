using Poodle.Data.EntityModels;
using System.Collections.Generic;
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
		Task<Course> DeleteAsync(Course course);

		Task EnrollInCourse(List<User> users, Course course);
		Task Unenroll(User user, Course course);
	}
}

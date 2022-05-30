using Poodle.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Repositories.Contracts
{
	public interface ICoursesRepository
	{
		Task<IEnumerable<Course>> GetAllAsync();
		Course GetById(int id);
		Course GetByTitle(string title);
		IQueryable<Course> Get(CourseQueryParameters filterParameters);
		Task<Course> CreateAsync(Course course);
		Task<Course> UpdateAsync(int id, Course course);
		Task<Course> DeleteAsync(int id);
	}
}

using Poodle.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
	public interface ICoursesService
	{
		Task<IEnumerable<Course>> GetAllAsync();
		Course GetById(int id);
		IQueryable<Course> Get(CourseQueryParameters filterParameters);
		Task<Course> Create(Course course);
		Task<Course> Update(int id, Course course);
		Task<Course> DeleteAsync(int id);

	}
}

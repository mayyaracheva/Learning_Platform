using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Services
{
	public class CoursesService : ICoursesService
	{
		private readonly ICoursesRepository repository;

		public CoursesService(ICoursesRepository repository)
		{
			this.repository = repository;
		}

		public Task<IEnumerable<Course>> GetAllAsync()
		{
			return this.repository.GetAllAsync();
		}
		public Course GetById(int id)
		{
			return this.repository.GetById(id);
		}
		public IQueryable<Course> Get(CourseQueryParameters filterParameters)
		{
			throw new NotImplementedException();
		}
		public Task<Course> Create(Course course)
		{
			throw new NotImplementedException();
		}
		public Task<Course> Update(int id, Course course)
		{
			throw new NotImplementedException();
		}

		public Task<Course> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}

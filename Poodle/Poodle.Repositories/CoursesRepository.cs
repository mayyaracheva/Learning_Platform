using Microsoft.EntityFrameworkCore;
using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Repositories
{
	public class CoursesRepository : ICoursesRepository
	{
		private readonly ApplicationContext context;
		public CoursesRepository(ApplicationContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<Course>> GetAllAsync()
		{
			return await this.context.Courses
								.Where(p => !p.IsDeleted)
								.ToListAsync();
		}
	}
}

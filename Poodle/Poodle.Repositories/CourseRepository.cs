using Microsoft.EntityFrameworkCore;
using Poodle.Data;
using Poodle.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Repositories
{
	public class CourseRepository : ICourseRepository
	{
		private readonly ApplicationContext context;
		public CourseRepository(ApplicationContext context)
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

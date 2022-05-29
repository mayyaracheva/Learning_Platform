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
	}
}

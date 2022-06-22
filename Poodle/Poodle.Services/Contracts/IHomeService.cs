using Poodle.Data.EntityModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
	public interface IHomeService
	{
		IQueryable<Course> GetPublicCoursrses();
	}
}

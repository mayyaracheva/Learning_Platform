using Poodle.Data.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
	public interface IHomeService
	{
		Task<IEnumerable<Course>> GetAllPublicCoursrses();
	}
}

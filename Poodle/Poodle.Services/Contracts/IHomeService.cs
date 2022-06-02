using Poodle.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
	public interface IHomeService
	{
		Task<List<CourseResponseDTO>> GetPublicCoursrsesAsync();
	}
}

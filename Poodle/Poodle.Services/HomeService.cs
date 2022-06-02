using Microsoft.EntityFrameworkCore;
using Poodle.Repositories.Contracts;
using Poodle.Services.Constants;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Services
{
	public class HomeService : IHomeService
	{
        private readonly ICoursesRepository coursesRepository;

        public HomeService(ICoursesRepository coursesRepository)
        {
            this.coursesRepository = coursesRepository;
        }

        public async Task<List<CourseResponseDTO>> GetPublicCoursrsesAsync()
        {
            var allPublicCourses = this.coursesRepository.GetAll();
            var result = await allPublicCourses
                .Where(x => x.Category.Name == ConstantsContainer.PUBLIC_CATEGORY)
                .Select(p => new CourseResponseDTO(p))
                .ToListAsync();
            return result;
        }


    }
}

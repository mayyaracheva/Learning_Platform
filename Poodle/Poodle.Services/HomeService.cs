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
	public class HomeService : IHomeService
	{
        private readonly ICoursesRepository coursesRepository;

        public HomeService(ICoursesRepository coursesRepository)
        {
            this.coursesRepository = coursesRepository;
        }

        public async Task<IEnumerable<Course>> GetAllPublicCoursrses()
        {
            var allPublicCourses = await this.coursesRepository.GetAllAsync();
            var result = allPublicCourses.Where(x => x.Category.Name == "Public");
            return result;
        }


    }
}

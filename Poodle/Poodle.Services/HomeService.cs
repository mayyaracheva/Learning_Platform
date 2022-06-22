using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services.Constants;
using Poodle.Services.Contracts;
using System.Linq;

namespace Poodle.Services
{
	public class HomeService : IHomeService
	{
        private readonly ICoursesRepository coursesRepository;

        public HomeService(ICoursesRepository coursesRepository)
        {
            this.coursesRepository = coursesRepository;
        }

        public IQueryable<Course> GetPublicCoursrses()
        {
            var allPublicCourses = this.coursesRepository.GetAll()
                .Where(x => x.Category.Name == ConstantsContainer.PUBLIC_CATEGORY);

            return allPublicCourses;
        }


    }
}

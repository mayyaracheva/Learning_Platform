using Poodle.Services.Exceptions;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services.Contracts;
using System.Threading.Tasks;
using Poodle.Services.Constants;
using Microsoft.EntityFrameworkCore;
using Poodle.Services.Dtos;
using Poodle.Services.Mappers;
using Poodle.Services.Helpers;
using System.Collections.Generic;
using System.Linq;
using Poodle.Web.Models;

namespace Poodle.Services
{
	public class CoursesService : ICoursesService
	{
		private readonly ICoursesRepository coursesRepository;
		private readonly IUsersRepository usersRepository;
		private readonly CourseMapper courseMapper;

		public CoursesService(ICoursesRepository repository,
								CourseMapper courseMapper,
								IUsersRepository usersRepository)
		{
			this.courseMapper = courseMapper;
			this.coursesRepository = repository;
			this.usersRepository = usersRepository;
		}

		//user type check - diff access level
		public async Task<dynamic> GetAsync(User user)
		{
			if (AuthorizationHelper.IsStudent(user))
			{
				var courses = await this.coursesRepository.GetAll()
					.Where(course => (course.Category.Name == ConstantsContainer.PUBLIC_CATEGORY)
							&& (course.Users.Contains(user)))
					.Select(course => new CourseViewModel(course))
					.ToListAsync();
				return courses;
			}
			return await this.coursesRepository.GetAll().ToListAsync();
		}

		/* - user type check - diff access level */
		public async Task<Course> Get(int id, User user)
		{
			var course = await ExistingCourseCheck(id);

			if (AuthorizationHelper.IsStudent(user))
			{
				if (!course.Category.Name.Equals(ConstantsContainer.PUBLIC_CATEGORY) && !user.Courses.Contains(course))
				{
					throw new UnauthorizedOperationException(ConstantsContainer.RESTRICTED_ACCESS);
				}
				EnrollInPublicCourse(new List<User> {user}, course);
			}
			return course;
		}

		public void EnrollInPublicCourse(List<User> users, Course course)
		{
			this.coursesRepository.EnrollInCourse(users, course);
		}

		public async void EnrollInPrivateCourse(int id, User user)
        {
            AuthorizationHelper.ValidateAccess(user.Role.Name);
            var users = await GetUsersNotEnroled(id);


        }
		
		public async Task<dynamic> Get(CourseQueryParameters filterParameters, User user)
		{
			if (!filterParameters.NoQueryParameters)
			{
				var courses = await this.coursesRepository
				.Get(filterParameters)
				.ToListAsync();

				return courses;
			}
			else
			{
				return await this.GetAsync(user);
			}
		}
		public async Task<Course> CreateAsync(CourseViewModel dto, User user)
		{
			AuthorizationHelper.ValidateAccess(user.Role.Name);
			await this.DuplicateCourseCheck(dto);

			var newCourse = this.courseMapper.Convert(dto);
			await this.coursesRepository.CreateAsync(newCourse);

			return newCourse;
		}

        public async Task<Course> UpdateAsync(int id, User user, CourseUpdateDTO dto)
        {
            AuthorizationHelper.ValidateAccess(user.Role.Name);

			var courseToUpdate = await ExistingCourseCheck(id); 
                
            var course = this.courseMapper.Convert(dto);

            return await this.coursesRepository.UpdateAsync(courseToUpdate, course);
        }

        public async Task<Course> DeleteAsync(int id, User user)
        {
            AuthorizationHelper.ValidateAccess(user.Role.Name);
            var courseToDelete = await ExistingCourseCheck(id);

            return await this.coursesRepository.DeleteAsync(courseToDelete);
        }

		private async Task<List<User>> GetUsersNotEnroled(int id)
		{
			var course = await ExistingCourseCheck(id);
			var usersNotInCourse = await this.usersRepository.GetAll().Where(x => !x.Courses.Contains(course)).ToListAsync();
			return usersNotInCourse;
		}

		private async Task<Course> ExistingCourseCheck(int id)
        {
			var course = await this.coursesRepository.Get(id).FirstOrDefaultAsync()
				?? throw new EntityNotFoundException(ConstantsContainer.COURSE_NOT_FOUND);

			return course;
        }

        private async Task DuplicateCourseCheck(CourseViewModel dto)
		{
			var course = await this.coursesRepository.GetByTitle(dto.Title).FirstAsync();
			if ( course != null)
			{
				throw new DuplicateEntityException(ConstantsContainer.COURSE_EXISTS);
			}
		}
	}
}

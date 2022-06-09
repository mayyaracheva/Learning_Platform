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
		public async Task<CourseResponseDTO> Get(int id, User user)
		{
			var course = await ExistingCourseCheck(id);

			if (AuthorizationHelper.IsStudent(user))
			{
				if (course.Category.Name.Equals(ConstantsContainer.PUBLIC_CATEGORY) && !user.Courses.Contains(course))
				{
					throw new UnauthorizedOperationException(ConstantsContainer.RESTRICTED_ACCESS);
				}
				user.Courses.Add(course);
			}
			return this.courseMapper.ConvertToDTO(course);
		}

        public async void EnrollInPrivateCourse(int id, User user)
        {
            AuthorizationHelper.ValidateAccess(user.Role.Name);
            var users = await GetUsersNotEnroled(id);
        }

        private async Task<List<User>> GetUsersNotEnroled(int id)
		{
			var course = await ExistingCourseCheck(id);
			var usersNotInCourse =  await this.usersRepository.GetAll().Where(x => !x.Courses.Contains(course)).ToListAsync();
			return usersNotInCourse;
		}
		
		public async Task<List<Course>> Get(CourseQueryParameters filterParameters)
		{
			var courses = await this.coursesRepository
				.Get(filterParameters)
				.ToListAsync();

			return courses;
		}
		public async Task<Course> CreateAsync(CourseCreateDTO dto, User user)
		{
			AuthorizationHelper.ValidateAccess(user.Role.Name);
			DuplicateCourseCheck(dto);

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

            return await this.coursesRepository.DeleteAsync(id, courseToDelete);
        }

        private async Task<Course> ExistingCourseCheck(int id)
        {
			var course = await this.coursesRepository.Get(id).FirstOrDefaultAsync()
				?? throw new EntityNotFoundException(ConstantsContainer.COURSE_NOT_FOUND);

			return course;
        }

        private void DuplicateCourseCheck(CourseCreateDTO dto)
		{
			if (this.coursesRepository.GetByTitle(dto.Title) != null)
			{
				throw new DuplicateEntityException(ConstantsContainer.COURSE_EXISTS);
			}
		}
	}
}

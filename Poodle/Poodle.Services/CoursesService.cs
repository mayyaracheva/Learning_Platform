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

namespace Poodle.Services
{
	public class CoursesService : ICoursesService
	{
		private readonly ICoursesRepository coursesRepository;
		private readonly IHomeService homeService;
		private readonly IUsersRepository usersRepository;
		private readonly CourseMapper courseMapper;

		public CoursesService(ICoursesRepository repository,
								CourseMapper courseMapper,
								IHomeService homeService,
								IUsersRepository usersRepository)
		{
			this.courseMapper = courseMapper;
			this.coursesRepository = repository;
			this.homeService = homeService;
			this.usersRepository = usersRepository;
		}

		//user type check - diff access level
		public async Task<dynamic> GetAsync(User user)
		{
			if (AuthorizationHelper.IsStudent(user))
			{
				return await this.homeService.GetPublicCoursrsesAsync();
			}
			return await this.coursesRepository.GetAll().ToListAsync();
		}


		/* - user type check - diff access level */
		public CourseResponseDTO Get(int id, User user)
		{
			var course = this.coursesRepository.Get(id)
				?? throw new EntityNotFoundException(ConstantsContainer.COURSE_NOT_FOUND);

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

		public void EnrollInPrivateCourse(int id, User user)
		{
			AuthorizationHelper.ValidateAccess(user.Role.Name);
			GetUsersNotEnroled(id);
		}

		private List<User> GetUsersNotEnroled(int id)
		{
			var course = this.coursesRepository.Get(id);
			var usersNotInCourse =  this.usersRepository.GetAll().Where(x => !x.Courses.Contains(course)).ToList();
			return usersNotInCourse;
		}
		//TODO - have to decide if we implement this functionality
		/*public async Task<List<Course>> Get(CourseQueryParameters filterParameters)
		{
			var courses = await this.coursesRepository
				.Get(filterParameters)
				.ToListAsync();

			return courses;
		}*/
		public async Task<Course> CreateAsync(CourseDTO dto, User user)
		{
			AuthorizationHelper.ValidateAccess(user.Role.Name);
			DuplicateCourseCheck(dto);

			var newCourse = this.courseMapper.Convert(dto);
			await this.coursesRepository.CreateAsync(newCourse);

			return newCourse;
		}

		public async Task<Course> UpdateAsync(int id, User user, CourseDTO dto)
		{
			AuthorizationHelper.ValidateAccess(user.Role.Name);

			var courseToUpdate = this.coursesRepository.Get(id)
				?? throw new EntityNotFoundException(ConstantsContainer.COURSE_NOT_FOUND);

			var course = this.courseMapper.Convert(dto);

			return await this.coursesRepository.UpdateAsync(courseToUpdate, course);
		}

		public async Task<Course> DeleteAsync(int id, User user)
		{
			AuthorizationHelper.ValidateAccess(user.Role.Name);
			var courseToDelete = CheckIfCourseExists(id);

			return await this.coursesRepository.DeleteAsync(id, courseToDelete);
		}

		private Course CheckIfCourseExists(int id)
		{
			var course = this.coursesRepository.Get(id);
			if (course == null)
			{
				throw new EntityNotFoundException(ConstantsContainer.COURSE_NOT_FOUND);
			}
			return course;
		}

		private void DuplicateCourseCheck(CourseDTO dto)
		{
			if (this.coursesRepository.GetByTitle(dto.Title) != null)
			{
				throw new DuplicateEntityException(ConstantsContainer.COURSE_EXISTS);
			}
		}
	}
}

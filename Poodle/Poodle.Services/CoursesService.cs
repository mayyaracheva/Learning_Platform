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
using System;

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

		//user role check - diff Courses access level, returns diff type
		public async Task<dynamic> GetAsync(User user)
		{
			if (AuthorizationHelper.IsStudent(user))
			{
				var courses = await this.coursesRepository.GetAll()
					.Where(course => (course.Category.Name == ConstantsContainer.PUBLIC_CATEGORY)
							&& (course.Users.Contains(user)))
					.Select(course => new StudentCourseViewModel(course))
					.ToListAsync();
				return courses;
			}
			return await this.coursesRepository.GetAll().ToListAsync();
		}

		public async Task<Course> GetExistingCourse(int id)
			=> await this.coursesRepository.Get(id).FirstOrDefaultAsync()
				?? throw new EntityNotFoundException(ConstantsContainer.COURSE_NOT_FOUND);


		//public List<T> GetCourses<T>(User user) where T : CourseViewModel,new()
		//      {
		//	if(AuthorizationHelper.IsStudent(user))
		//          {
		//		var courses = this.coursesRepository.GetAll()
		//			.Where(course => (course.Category.Name == ConstantsContainer.PUBLIC_CATEGORY)
		//					&& (course.Users.Contains(user)))
		//			.Select(course => new CourseViewModel(course))
		//			.ToList();
		//		return courses.OfType<T>();
		//	}

		//	throw new NotImplementedException();
		//      }			

		public async Task<PaginatedList<StudentCourseViewModel>> StudentGetCourses(CourseQueryParameters filterParameters, User user)
		{
			var courses = await this.coursesRepository
			.Get(filterParameters)
			.Where(course => course.Users.Contains(user))
			.Select(course => new StudentCourseViewModel(course))
			.ToListAsync();

			IEnumerable<StudentCourseViewModel> paginatedCourses = courses
					.Skip((filterParameters.PageNumber - 1) * filterParameters.PageSize)
					.Take(filterParameters.PageSize);

			int totalPages = (courses.Count - 1) / filterParameters.PageSize + 1;
			return new PaginatedList<StudentCourseViewModel>(paginatedCourses, totalPages, filterParameters.PageNumber);
		}
		public async Task<PaginatedList<TeacherCourseViewModel>> TeacherGetCourses(CourseQueryParameters filterParameters, User user)
		{
			var courses = await this.coursesRepository
				.Get(filterParameters)
				.Select(course => new TeacherCourseViewModel(course))
				.ToListAsync();

			IEnumerable<TeacherCourseViewModel> paginatedCourses = courses
					.Skip((filterParameters.PageNumber - 1) * filterParameters.PageSize)
					.Take(filterParameters.PageSize);

			int totalPages = (courses.Count - 1) / filterParameters.PageSize + 1;

			return new PaginatedList<TeacherCourseViewModel>(paginatedCourses, totalPages, filterParameters.PageNumber);
		}
		public async Task<Course> CreateAsync(CourseDTO dto, User user)
		{
			AuthorizationHelper.ValidateAccess(user.Role.Name);
			await this.DuplicateCourseCheck(dto.Title);

			var newCourse = this.courseMapper.Convert(dto);
			await this.coursesRepository.CreateAsync(newCourse);

			return newCourse;
		}

		public async Task<Course> UpdateAsync(int id, User user, CourseDTO dto)
		{
			AuthorizationHelper.ValidateAccess(user.Role.Name);

			var courseToUpdate = await GetExistingCourse(id);

			var course = this.courseMapper.Convert(dto);

			return await this.coursesRepository.UpdateAsync(courseToUpdate, course);
		}

		public async Task<Course> DeleteAsync(int id, User user)
		{
			AuthorizationHelper.ValidateAccess(user.Role.Name);
			var courseToDelete = await GetExistingCourse(id);

			return await this.coursesRepository.DeleteAsync(courseToDelete);
		}

		public async Task<Course> EnrollStudentInPublicCourse(int id, User user)
		{
			var course = await GetExistingCourse(id);

			if (AuthorizationHelper.IsStudent(user))
			{
				await this.coursesRepository.EnrollInCourse(new List<User> { user }, course);
			}
			return course;
		}

		public async Task<Course> EnrollStudentsInPrivateCourse(int id, List<User> users)
		{
			var course = await GetExistingCourse(id);

			await this.coursesRepository.EnrollInCourse(users, course);

			return course;
		}

		public async Task<List<User>> GetUsersNotEnrolled(int id)
		{
			var course = await GetExistingCourse(id);
			var usersNotInCourse = await this.usersRepository
				.GetAll()
				.Where(x => (!x.Courses.Contains(course)) && (x.Role.Name != ConstantsContainer.TEACHER))
				.ToListAsync();
			return usersNotInCourse;
		}

		public async Task Unenroll(int id, User user)
		{
			var course = await GetExistingCourse(id);

			await this.coursesRepository.Unenroll(user, course);
		}
		private async Task DuplicateCourseCheck(string title)
		{
			var course = await this.coursesRepository.GetByTitle(title).FirstOrDefaultAsync();
			if (course != null)
			{
				throw new DuplicateEntityException(ConstantsContainer.COURSE_EXISTS);
			}
		}
	}
}

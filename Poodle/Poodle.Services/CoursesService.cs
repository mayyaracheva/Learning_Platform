using Poodle.Services.Exceptions;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poodle.Services.Constants;
using Microsoft.EntityFrameworkCore;
using Poodle.Services.Dtos;
using Poodle.Services.Mappers;
using Poodle.Services.Helpers;

namespace Poodle.Services
{
	public class CoursesService : ICoursesService
	{
		private readonly ICoursesRepository coursesRepository;
		private readonly CourseMapper courseMapper;
		private readonly AuthorizationHelper authorizationHelper;

		public CoursesService(ICoursesRepository repository, 
								CourseMapper courseMapper,
								AuthorizationHelper authorizationHelper)
		{
			this.courseMapper = courseMapper;
			this.coursesRepository = repository;
			this.authorizationHelper = authorizationHelper;
		}

		//TODO - check the user - student or teacher - diff access level
		public async Task<List<Course>> GetAsync()
		{
			return await this.coursesRepository
				.GetAll()
				.ToListAsync();
		}

		//TODO - check the user - student or teacher - diff access level
		public CourseResponseDTO Get(int id)
		{
			var course = this.coursesRepository.Get(id);
			if (course == null)
			{
				throw new EntityNotFoundException(string.Format(ConstantsContainer.COURSE_NOT_FOUND, id));
			}

			return this.courseMapper.ConvertToDTO(course);
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
			if (!this.authorizationHelper.IsTeacher(user))
			{
				throw new UnauthorizedOperationException(ConstantsContainer.RESTRICTED_ACCESS);
			}
			var duplicateCourse = this.coursesRepository
				.GetAll()
				.FirstOrDefault(x => x.Title == dto.Title);

			if (duplicateCourse != null)
			{
				throw new DuplicateEntityException(ConstantsContainer.COURSE_EXISTS);
			}
			var newCourse = this.courseMapper.Convert(dto);
			await this.coursesRepository.CreateAsync(newCourse);

			return newCourse;
		}
		public async Task<Course> UpdateAsync(int id, Course course)
		{
			return await this.coursesRepository.UpdateAsync(id, course);
		}

		public async Task<Course> DeleteAsync(int id)
		{
			return await this.coursesRepository.DeleteAsync(id);
		}
	}
}

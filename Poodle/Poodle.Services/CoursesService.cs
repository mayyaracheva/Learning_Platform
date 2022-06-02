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
			var course = this.coursesRepository.Get(id)
				??throw new EntityNotFoundException(ConstantsContainer.COURSE_NOT_FOUND);

			return this.courseMapper.ConvertToDTO(course);
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
			if (!this.authorizationHelper.IsTeacher(user))
			{
				throw new UnauthorizedOperationException(ConstantsContainer.RESTRICTED_ACCESS);
			}

			var newCourse = this.courseMapper.Convert(dto);
			var duplicateCourse = this.coursesRepository
				.GetByTitle(newCourse.Title)
					?? throw new DuplicateEntityException(ConstantsContainer.COURSE_EXISTS);

			
			await this.coursesRepository.CreateAsync(newCourse);

			return newCourse;
		}
		public async Task<Course> UpdateAsync(int id, User user, CourseDTO dto)
		{
			if (!this.authorizationHelper.IsTeacher(user))
			{
				throw new UnauthorizedOperationException(ConstantsContainer.RESTRICTED_ACCESS);
			}

			var courseToUpdate = this.coursesRepository.Get(id)
				?? throw new EntityNotFoundException(ConstantsContainer.COURSE_NOT_FOUND);
			
			var course = this.courseMapper.Convert(dto);

			return await this.coursesRepository.UpdateAsync(courseToUpdate, course);
		}

		public async Task<Course> DeleteAsync(int id)
		{
			return await this.coursesRepository.DeleteAsync(id);
		}
	}
}

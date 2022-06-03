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

		public CoursesService(ICoursesRepository repository, 
								CourseMapper courseMapper)
		{
			this.courseMapper = courseMapper;
			this.coursesRepository = repository;
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
			CheckIfCourseExists(id);

			return await this.coursesRepository.DeleteAsync(id);
		}

		private void CheckIfCourseExists(int id)
		{
			if (this.coursesRepository.Get(id) == null)
			{
				throw new EntityNotFoundException(ConstantsContainer.COURSE_NOT_FOUND);
			}
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

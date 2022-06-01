using Poodle.Services.Exceptions;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Services
{
	public class CoursesService : ICoursesService
	{
		private readonly ICoursesRepository coursesRepository;

		public CoursesService(ICoursesRepository repository)
		{
			this.coursesRepository = repository;
		}

		public async Task<IEnumerable<Course>> GetAllAsync()
		{
			return await this.coursesRepository.GetAllAsync();
		}
		public Course GetById(int id)
		{
			return this.coursesRepository.GetById(id)
				?? throw new EntityNotFoundException($"There is no course with id: {id}");
		}
		public async Task<IQueryable<Course>> Get(CourseQueryParameters filterParameters)
		{
			var courses = await this.coursesRepository.Get(filterParameters);

			return courses;
		}
		public async Task<Course> CreateAsync(Course course)
		{
			var duplicateCourse = this.coursesRepository
				.GetAllAsync()
				.Result
				.FirstOrDefault(x => x.Title == course.Title);

			if (duplicateCourse != null)
			{
				throw new DuplicateEntityException("This course already exists");
			}

			course.CreatedOn = DateTime.UtcNow;
			Course createdCourse = await this.coursesRepository.CreateAsync(course);

			return createdCourse;
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

using Microsoft.EntityFrameworkCore;
using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Repositories
{
	public class CoursesRepository : ICoursesRepository
	{
		private readonly ApplicationContext context;
		public CoursesRepository(ApplicationContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<Course>> GetAllAsync()
		{
			var result = await this.GetCourses()
								.Where(x => !x.IsDeleted)
								.ToListAsync();
			return result;
		}

		public Course GetById(int id)
		{
			var result = this.GetCourses()
				.Where(x => x.Id == id)
				.FirstOrDefault();
			return result;
		}

		public Course GetByTitle(string title)
		{
			var result = this.GetCourses()
				.Where(x => x.Title == title)
				.FirstOrDefault();
			return result;
		}
		public IQueryable<Course> Get(CourseQueryParameters filterParameters)
		{
			string title = !string.IsNullOrEmpty(filterParameters.Title) ? filterParameters.Title.ToLowerInvariant() : string.Empty;
			string category = !string.IsNullOrEmpty(filterParameters.Category) ? filterParameters.Category.ToLowerInvariant() : string.Empty;
			string sortCriteria = !string.IsNullOrEmpty(filterParameters.SortBy) ? filterParameters.SortBy.ToLowerInvariant() : string.Empty;
			string sortOrder = !string.IsNullOrEmpty(filterParameters.SortOrder) ? filterParameters.SortOrder.ToLowerInvariant() : string.Empty;

			var courses = (IQueryable < Course >)this.GetAllAsync();

			courses = FilterByTitle(courses, title);
			courses = FilterByCategory(courses, category);
			courses = SortBy(courses, sortCriteria);
			courses = Order(courses, sortOrder);

			return courses;

		}

		public async Task<Course> CreateAsync(Course course)
		{
			var createdCourse = await this.context.Courses.AddAsync(course);

			await this.context.SaveChangesAsync();

			return createdCourse.Entity;
		}

		public async Task<Course> UpdateAsync(int id, Course course)
		{
			Course existingCourse = this.GetById(id);

			existingCourse.Title = course.Title != null ? course.Title : existingCourse.Title;
			existingCourse.Description = course.Description != null ? course.Description : existingCourse.Description;

			await this.context.SaveChangesAsync();

			return existingCourse;
		}

		public async Task<Course> DeleteAsync(int id)
		{
			var courseToDelete = await this.context.Courses
						   .FirstOrDefaultAsync(p => p.Id == id);

			courseToDelete.IsDeleted = true;
			//courseToDelete.DeletedOn = DateTime.UtcNow;

			await this.context.SaveChangesAsync();

			return courseToDelete;
		}

		private static IQueryable<Course> FilterByTitle(IQueryable<Course> courses, string title)
		{
			var result = courses.Where(courses => courses.Title.Contains(title));
			return result;
		}

		private static IQueryable<Course> FilterByCategory(IQueryable<Course> courses, string category)
		{
			return courses.Where(courses => courses.Category.Name.Contains(category));
		}

		private static IQueryable<Course> SortBy(IQueryable<Course> courses, string sortCriteria)
		{
			switch (sortCriteria)
			{
				case "title":
					return courses.OrderBy(courses => courses.Title);
				case "category":
					return courses.OrderBy(courses => courses.Category);
				default:
					return courses;
			}
		}

		private static IQueryable<Course> Order(IQueryable<Course> courses, string sortOrder)
		{
			return (sortOrder == "desc") ? courses.Reverse() : courses;
		}

		private IQueryable<Course> GetCourses()
		{
			return this.context.Courses
					.Include(course => course.Sections)
						.ThenInclude(section => section.Title)
					.Include(course => course.Users)
						.ThenInclude(user => user.FirstName)
						.Include(course => course.Users)
						.ThenInclude(user => user.LastName);
		}
	}
}

﻿using Microsoft.EntityFrameworkCore;
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

		public IQueryable<Course> GetAll()
			=> this.GetCourses();

		public IQueryable<Course> Get(int id)
			=> this.GetCourses().Where(x => x.Id == id);
					

		public IQueryable<Course> GetByTitle(string title)
			=>	this.GetCourses().Where(x => x.Title == title);

		public async Task EnrollInCourse(List<User> user, Course course)
		{
			course.Users.AddRange(user);
			await this.context.SaveChangesAsync();
		}
		public async Task Unenroll(User user, Course course)
		{
			course.Users.Remove(user);
			await this.context.SaveChangesAsync();
		}
		public IQueryable<Course> Get(CourseQueryParameters filterParameters)
		{
			string title = !string.IsNullOrEmpty(filterParameters.Title) ? filterParameters.Title.ToLowerInvariant() : string.Empty;
			string category = !string.IsNullOrEmpty(filterParameters.Category) ? filterParameters.Category.ToLowerInvariant() : string.Empty;
			string sortCriteria = !string.IsNullOrEmpty(filterParameters.SortBy) ? filterParameters.SortBy.ToLowerInvariant() : string.Empty;
			string sortOrder = !string.IsNullOrEmpty(filterParameters.SortOrder) ? filterParameters.SortOrder.ToLowerInvariant() : string.Empty;

			var courses = this.GetAll();

			courses = FilterByTitle(courses, title);
			courses = FilterByCategory(courses, category);
			courses = SortBy(courses, sortCriteria);
			courses = Order(courses, sortOrder);

			return courses;

		}

		public async Task<Course> CreateAsync(Course course)
		{
			course.CreatedOn = DateTime.Now;
			var createdCourse = await this.context.Courses.AddAsync(course);
			await this.context.SaveChangesAsync();

			return createdCourse.Entity;
		}

		public async Task<Course> UpdateAsync(Course courseToUpdate, Course course)
		{
			courseToUpdate.Title = course.Title != null ? course.Title : courseToUpdate.Title;
			courseToUpdate.Description = course.Description != null ? course.Description : courseToUpdate.Description;
			courseToUpdate.CategoryId = course.CategoryId != 0 ? course.CategoryId : courseToUpdate.CategoryId;
			courseToUpdate.PhotoURL = course.PhotoURL != null ? course.PhotoURL : courseToUpdate.PhotoURL;

			courseToUpdate.ModifiedOn = DateTime.UtcNow;

			await this.context.SaveChangesAsync();

			return courseToUpdate;
		}

		public async Task<Course> DeleteAsync(Course courseToDelete)
		{
			this.context.Courses.Remove(courseToDelete);

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
			return this.context.Courses.Where(x => !x.IsDeleted).OrderByDescending(x => x.CreatedOn)
					.Include(course => course.Category)
					.Include(course => course.Sections.Where(s => !s.IsDeleted).OrderBy(s => s.Rank))
					.Include(course => course.Users);
		}
	}
}

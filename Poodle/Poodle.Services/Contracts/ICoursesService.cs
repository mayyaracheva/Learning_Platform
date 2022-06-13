﻿using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using Poodle.Web.Models;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
	public interface ICoursesService
	{
		Task<dynamic> GetAsync(User user);
		Task<Course> Get(int id, User user);

		Task<dynamic> Get(CourseQueryParameters filterParameters, User user);
		Task<Course> CreateAsync(CourseViewModel course, User user);
		Task<Course> UpdateAsync(int id, User user, CourseUpdateDTO dto);
		Task<Course> DeleteAsync(int id, User user);

	}
}

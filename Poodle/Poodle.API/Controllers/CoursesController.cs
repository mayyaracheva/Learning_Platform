﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using Poodle.Data.EntityModels;
using Poodle.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CoursesController :ControllerBase
	{
		private readonly CourseMapper userMapper;
		private readonly ICoursesService coursesService;
		private readonly IUsersService usersService;

		public CoursesController(CourseMapper courseMapper, ICoursesService coursesService, IUsersService usersService)
		{
			this.userMapper = courseMapper;
			this.coursesService = coursesService;
			this.usersService = usersService;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAllCourses([FromHeader] string email, [FromHeader] string password, [FromQuery] CourseQueryParameters filterParameters)
		{
			try
			{
				this.usersService.CheckAuthorization(email, password);
				/*List<CourseResponseDTO>*/ var courses = await this.coursesService.Get(filterParameters);
				return this.StatusCode(StatusCodes.Status200OK, courses);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}

			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
		}



	}
}
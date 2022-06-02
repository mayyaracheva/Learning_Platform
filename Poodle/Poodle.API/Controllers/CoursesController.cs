using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using Poodle.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Poodle.Services.Helpers;

namespace Poodle.Services.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CoursesController :ControllerBase
	{
		private readonly CourseMapper userMapper;
		private readonly ICoursesService coursesService;
		private readonly IUsersService usersService;
		private readonly ISectionService sectionService;
		private readonly AuthenticationHelper authenticationHelper;

		public CoursesController(CourseMapper courseMapper, ICoursesService coursesService, IUsersService usersService, ISectionService sectionService, AuthenticationHelper authenticationHelper)
		{
			this.userMapper = courseMapper;
			this.coursesService = coursesService;
			this.usersService = usersService;
            this.sectionService = sectionService;
            this.authenticationHelper = authenticationHelper;
        }

		[HttpGet("")]
		public async Task<IActionResult> GetAsync([FromHeader] string email, [FromHeader] string password)
		{
			try
			{
				await this.authenticationHelper.TryGetUser(email, password);
				var courses = await this.coursesService
					.GetAsync();

				return this.StatusCode(StatusCodes.Status200OK, courses);
			}		
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}

			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}

		}

		[HttpGet("{id}/sections")]
		public async Task<IActionResult> GetSections(int id, [FromHeader] string email, [FromHeader] string password)
		{
			//only teacher set to be authorized to get all sections
			//authorization checked in services
			try
			{
				await this.authenticationHelper.TryGetUser(email, password);
				var sections = await this.sectionService.GetByCourseId(id, email, password);
				return this.StatusCode(StatusCodes.Status200OK, sections);
			}
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}

		}

		[HttpPost("{id}/sections")]

		public async Task<IActionResult> CreateSection(int id, [FromBody] string title, [FromBody] string content, [FromHeader] string email, [FromHeader] string password)
		{
			//only teacher set to be authorized to create sections
			//authorization checked in services			
			try
			{
				await this.authenticationHelper.TryGetUser(email, password);
				var sectionId = await this.sectionService.Create(id, title, content, email, password);
				return this.StatusCode(StatusCodes.Status201Created);
			}
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}

		}

	}
}

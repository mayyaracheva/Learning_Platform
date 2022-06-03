using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Exceptions;
using Poodle.Services.Contracts;
using System.Threading.Tasks;
using Poodle.Services.Helpers;
using Poodle.Services.Dtos;
using Poodle.Services.Constants;

namespace Poodle.Services.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CoursesController :ControllerBase
	{
		private readonly ICoursesService coursesService;
		private readonly ISectionService sectionService;
		private readonly AuthenticationHelper authenticationHelper;

		public CoursesController(ICoursesService coursesService, 
								 ISectionService sectionService, 
								 AuthenticationHelper authenticationHelper)
		{
			this.coursesService = coursesService;
            this.sectionService = sectionService;
            this.authenticationHelper = authenticationHelper;
        }

		[HttpGet("")]
		public async Task<IActionResult> Get([FromHeader] string email, [FromHeader] string password)
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
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id, [FromHeader] string email, [FromHeader] string password)
		{
			try
			{
				await this.authenticationHelper.TryGetUser(email, password);
				var course = this.coursesService.Get(id);
				return this.StatusCode(StatusCodes.Status200OK, course);
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


		[HttpPost("")]
		public async Task<IActionResult> Create([FromHeader] string email, [FromHeader] string password, [FromBody] CourseDTO course)
		{
			try
			{
				var user = await this.authenticationHelper.TryGetUser(email, password); 
				var newCourse = await this.coursesService.CreateAsync(course, user);

				return this.StatusCode(StatusCodes.Status201Created, ConstantsContainer.COURSE_CREATED);
			}
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
			catch (DuplicateEntityException e)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
			}

		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromHeader] string email, [FromHeader] string password, [FromBody] CourseDTO dto)
		{
			try
			{
				var user = await this.authenticationHelper.TryGetUser(email, password);

				var courseToUpdate = await this.coursesService.UpdateAsync(id, user, dto);
				
				return this.StatusCode(StatusCodes.Status200OK, ConstantsContainer.COURSE_UPDATED);
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

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id, [FromHeader] string email, [FromHeader] string password)
		{
			try
			{
				var user = await this.authenticationHelper.TryGetUser(email, password);

				var courseToDelete = await this.coursesService.DeleteAsync(id, user);

				return this.StatusCode(StatusCodes.Status200OK, ConstantsContainer.COURSE_DELETED);
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
				var requester = await this.authenticationHelper.TryGetUser(email, password);
				var sections = await this.sectionService.GetByCourseId(id, requester);
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

		public async Task<IActionResult> CreateSection(int id, [FromBody] SectionDto sectionDto, [FromHeader] string email, [FromHeader] string password)
		{
			//only teacher set to be authorized to create sections
			//authorization checked in services			
			try
			{
				var requester = await this.authenticationHelper.TryGetUser(email, password);
				var sectionId = await this.sectionService.Create(id, sectionDto, requester);
				return this.StatusCode(StatusCodes.Status201Created);
			}
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
		}
				
		[HttpDelete("sections/{id}")]
		public async Task<IActionResult> DeleteSection(int id, [FromHeader] string email, [FromHeader] string password)
		{
			try
			{
				var requester = await this.authenticationHelper.TryGetUser(email, password);
				await this.sectionService.Delete(id, requester);
				return this.StatusCode(StatusCodes.Status200OK, ConstantsContainer.SECTIONS_DELETED);
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

		
		[HttpPut("{courseId}/sections/{sectionId}")]
		public async Task<IActionResult> UpdateSection(int courseId, int sectionId, [FromBody] SectionDto sectionDto, [FromHeader] string email, [FromHeader] string password)
		{
			try
			{
				var requester = await this.authenticationHelper.TryGetUser(email, password);				
				var result = await this.sectionService.Update(courseId, sectionId, sectionDto, requester);

				return this.StatusCode(StatusCodes.Status200OK, result);
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
	}
}

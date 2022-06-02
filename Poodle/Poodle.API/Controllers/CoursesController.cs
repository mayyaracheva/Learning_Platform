using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Exceptions;
using Poodle.Services.Contracts;
using System.Threading.Tasks;
using Poodle.Services.Helpers;
using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;

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

		//authenticated users must be able to view posts /their or of other users/ with an option to filter and sort them
		//[HttpGet("filter")]
		//public IActionResult FilterPosts([FromQuery] PostQueryParameters filterParameters, [FromHeader] string email, [FromHeader] string password)
		//{
		//	try
		//	{
		//		this.authorizationhelper.TryGetUser(email, password);				
		//		List<PostResponseDto> posts = this.postsService.Get(filterParameters).Select(p => new PostResponseDto(p)).ToList();
		//		return this.StatusCode(StatusCodes.Status200OK, posts);
		//	}
		//	catch (UnauthorizedOperationException e)
		//	{
		//		return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
		//	}
		//	catch (Exception e)
		//	{

		//		return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
		//	}
		//}

		// authenticated users must be able to create a new post with at least a title and content.
		[HttpPost("")]
		public async Task<IActionResult> Create([FromHeader] string email, [FromHeader] string password, [FromBody] CourseDTO course)
		{
			try
			{
				var user = await this.authenticationHelper.TryGetUser(email, password); 
				var newCourse = await this.coursesService.CreateAsync(course, user);

				return this.StatusCode(StatusCodes.Status201Created, new { Title = newCourse.Title, Content = newCourse.Description, Access = newCourse.Category.Name });
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
				
				return this.StatusCode(StatusCodes.Status200OK, new { Title = courseToUpdate.Title, Content = courseToUpdate.Description, Access = courseToUpdate.Category.Name });
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

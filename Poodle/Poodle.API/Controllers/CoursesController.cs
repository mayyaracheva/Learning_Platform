using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Contracts;
using System.Threading.Tasks;
using Poodle.Services.Helpers;
using Poodle.Services.Dtos;
using Poodle.Services.Constants;
using Microsoft.AspNetCore.Cors;

namespace Poodle.Services.Controllers
{
	[EnableCors("MyPolicy")]
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]	
	public class CoursesController : ControllerBase
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
			var user = await this.authenticationHelper.TryGetUser(email, password);
			var courses = await this.coursesService.GetAsync(user);

			return this.StatusCode(StatusCodes.Status200OK, courses);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id, [FromHeader] string email, [FromHeader] string password)
		{
			var user = await this.authenticationHelper.TryGetUser(email, password);
			var course = await this.coursesService.GetExistingCourse(id);
			await this.coursesService.EnrollInPublicCourse(course, user);
			return this.StatusCode(StatusCodes.Status200OK, course);
		}


		[HttpPost("")]
		public async Task<IActionResult> Create([FromHeader] string email, [FromHeader] string password, [FromBody] CourseDTO course)
		{
			var user = await this.authenticationHelper.TryGetUser(email, password);
			await this.coursesService.CreateAsync(course, user);

			return this.StatusCode(StatusCodes.Status200OK, ConstantsContainer.COURSE_CREATED);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, CourseDTO dto)
		{
			var email = "Ragnar.Lodbrock@abv.com";
			var password = "adminADMIN123?";
			var user = await this.authenticationHelper.TryGetUser(email, password);

			var course = await this.coursesService.UpdateAsync(id, user, dto);

			return this.StatusCode(StatusCodes.Status200OK, ConstantsContainer.COURSE_CREATED);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var email = "Ragnar.Lodbrock@abv.com";
			var password = "adminADMIN123?";
			var user = await this.authenticationHelper.TryGetUser(email, password);

			await this.coursesService.DeleteAsync(id, user);

			return this.StatusCode(StatusCodes.Status200OK, ConstantsContainer.COURSE_DELETED);
		}

		[HttpGet("{id}/sections")]
		public async Task<IActionResult> GetSections(int id)
		{
			//only teacher set to be authorized to get all sections
			//authorization checked in services
			var email = "Ragnar.Lodbrock@abv.com";
			var password = "adminADMIN123?";
			var requester = await this.authenticationHelper.TryGetUser(email, password);
			var sections = await this.sectionService.GetByCourseId(id, requester);
			return this.StatusCode(StatusCodes.Status200OK, sections);
		}

		[HttpPost("{id}/sections")]

		public async Task<IActionResult> CreateSection(int id, SectionDto sectionDto, [FromHeader] string email, [FromHeader] string password)
		{
			//only teacher set to be authorized to create sections
			//authorization checked in services			
			var requester = await this.authenticationHelper.TryGetUser(email, password);
			var sectionId = await this.sectionService.CreateSection(sectionDto, id, requester);
			return this.StatusCode(StatusCodes.Status201Created);
		}

		[HttpDelete("sections/{id}")]
		public async Task<IActionResult> DeleteSection(int id, [FromHeader] string email, [FromHeader] string password)
		{
			var requester = await this.authenticationHelper.TryGetUser(email, password);
			await this.sectionService.DeleteSection(id, requester);
			return this.StatusCode(StatusCodes.Status200OK);
		}


		[HttpPut("{courseId}/sections/{sectionId}")]
		public async Task<IActionResult> UpdateSection(int courseId, int sectionId, [FromBody] SectionDto sectionDto, [FromHeader] string email, [FromHeader] string password)
		{
			var requester = await this.authenticationHelper.TryGetUser(email, password);
			var result = await this.sectionService.UpdateSection(courseId, sectionId, sectionDto, requester);

			return this.StatusCode(StatusCodes.Status200OK, result);
		}
	}
}

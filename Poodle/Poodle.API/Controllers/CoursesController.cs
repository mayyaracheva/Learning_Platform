using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
		private readonly ITeacherService sectionService;
		private readonly AuthenticationHelper authenticationHelper;

		public CoursesController(ICoursesService coursesService, 
								 ITeacherService sectionService, 
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
				var course = this.coursesService.Get(id, user);
				return this.StatusCode(StatusCodes.Status200OK, course);
		}


		[HttpPost("")]
		public async Task<IActionResult> Create([FromHeader] string email, [FromHeader] string password, [FromBody] CourseCreateDTO course)
		{
				var user = await this.authenticationHelper.TryGetUser(email, password); 
				await this.coursesService.CreateAsync(course, user);

				return this.StatusCode(StatusCodes.Status201Created, ConstantsContainer.COURSE_CREATED);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromHeader] string email, [FromHeader] string password, [FromBody] CourseUpdateDTO dto)
		{
				var user = await this.authenticationHelper.TryGetUser(email, password);

				var courseToUpdate = await this.coursesService.UpdateAsync(id, user, dto);
				
				return this.StatusCode(StatusCodes.Status200OK, ConstantsContainer.COURSE_UPDATED);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id, [FromHeader] string email, [FromHeader] string password)
		{
				var user = await this.authenticationHelper.TryGetUser(email, password);

				var courseToDelete = await this.coursesService.DeleteAsync(id, user);

				return this.StatusCode(StatusCodes.Status200OK, ConstantsContainer.COURSE_DELETED);
		}

		[HttpGet("{id}/sections")]
		public async Task<IActionResult> GetSections(int id, [FromHeader] string email, [FromHeader] string password)
		{
			//only teacher set to be authorized to get all sections
			//authorization checked in services
				var requester = await this.authenticationHelper.TryGetUser(email, password);
				var sections = await this.sectionService.GetByCourseId(id, requester);
				return this.StatusCode(StatusCodes.Status200OK, sections);
		}

		[HttpPost("{id}/sections")]

		public async Task<IActionResult> CreateSection(int id, [FromBody] SectionDto sectionDto, [FromHeader] string email, [FromHeader] string password)
		{
			//only teacher set to be authorized to create sections
			//authorization checked in services			
				var requester = await this.authenticationHelper.TryGetUser(email, password);
				var sectionId = await this.sectionService.CreateSection(id, sectionDto, requester);
				return this.StatusCode(StatusCodes.Status201Created, $"Section with Id {sectionId} created");
		}
				
		[HttpDelete("sections/{id}")]
		public async Task<IActionResult> DeleteSection(int id, [FromHeader] string email, [FromHeader] string password)
		{
				var requester = await this.authenticationHelper.TryGetUser(email, password);
				await this.sectionService.DeleteSection(id, requester);
				return this.StatusCode(StatusCodes.Status200OK, ConstantsContainer.SECTIONS_DELETED);
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

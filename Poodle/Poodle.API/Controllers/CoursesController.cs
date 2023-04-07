using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Contracts;
using System.Threading.Tasks;
using Poodle.Services.Helpers;
using Poodle.Services.Dtos;
using Poodle.Services.Constants;
using Microsoft.AspNetCore.Cors;
using Poodle.Data.EntityModels;
using Poodle.Web.Models;
using System.Linq;
using Poodle.Services.Exceptions;
using System.Collections.Generic;

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

		[Route("[action]")]
		[HttpGet]		
		public async Task<IActionResult> Get([FromHeader] string email, [FromHeader] string password)
		{		
			var user = await this.authenticationHelper.TryGetUser(email, password);
			var filterParams = new CourseQueryParameters();
			if (AuthorizationHelper.IsStudent(user))
			{
				var studentCourses = await this.coursesService.StudentGetCourses(filterParams, user);
				return this.StatusCode(StatusCodes.Status200OK, studentCourses);
			}

			var teacherCourses = await this.coursesService.TeacherGetCourses(filterParams, user);			
			return this.StatusCode(StatusCodes.Status200OK, teacherCourses);
		}
		
		[HttpGet("{id}/details")]
		public async Task<IActionResult> Details(int id, [FromHeader] string email, [FromHeader] string password)
		{			
			try
			{
				var user = await this.authenticationHelper.TryGetUser(email, password);
				var course = await this.coursesService.GetExistingCourse(id);
				await this.coursesService.EnrollInPublicCourse(course, user);				
				if (AuthorizationHelper.IsStudent(user))
				{
					var model = new StudentCourseViewModel(course);
					return this.StatusCode(StatusCodes.Status200OK, model);
				}
				else
				{
					var model = new TeacherCourseViewModel(course);
					return this.StatusCode(StatusCodes.Status200OK, model);
				}
			}
			catch (EntityNotFoundException e)
			{
				return this.NotFound(e);
			}
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized);
			}
		}
				
		[HttpGet("{id}/enroll")]
		public async Task<IActionResult> Enroll(int id)
		{			
			try
			{				
				var studentsNotEnrolled = await this.coursesService.GetUsersNotEnrolled(id);
				return this.StatusCode(StatusCodes.Status200OK, studentsNotEnrolled);
			}
			catch (EntityNotFoundException e)
			{
				return this.NotFound(e);
			}
		}

		[HttpPost("{id}/enroll")]	
		public async Task<IActionResult> Enroll(int id, string[] students)
		{			
			try
			{				
				var studentsNotEnrolled = await this.coursesService.GetUsersNotEnrolled(id);
				var enrolledStudents = new List<User>();

				foreach (var student in studentsNotEnrolled)
				{
					if (students.Contains(student.Id.ToString()))
					{
						enrolledStudents.Add(student);						
					}
				}
				await this.coursesService.EnrollStudentsInPrivateCourse(id, enrolledStudents);
				return this.StatusCode(StatusCodes.Status200OK, "Students successfully enrolled");
			}
			catch (EntityNotFoundException e)
			{
				return this.NotFound(e);
			}
			
		}

		[HttpGet("{id}/unenroll")]		
		public async Task<IActionResult> Unenroll(int id, [FromHeader] string email, [FromHeader] string password)
		{
			try
			{
				var user = await this.authenticationHelper.TryGetUser(email, password);
				await this.coursesService.Unenroll(id, user);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, "Course not found");
			}
						
			return this.StatusCode(StatusCodes.Status200OK, "Successfully unenrolled");
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
		public async Task<IActionResult> Update(int id, [FromHeader] string email, [FromHeader] string password, [FromBody] CourseDTO dto)
		{			
			var user = await this.authenticationHelper.TryGetUser(email, password);

			await this.coursesService.UpdateAsync(id, user, dto);

			return this.StatusCode(StatusCodes.Status200OK, ConstantsContainer.COURSE_UPDATED);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id, [FromHeader] string email, [FromHeader] string password)
		{			
			var user = await this.authenticationHelper.TryGetUser(email, password);

			await this.coursesService.DeleteAsync(id, user);

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

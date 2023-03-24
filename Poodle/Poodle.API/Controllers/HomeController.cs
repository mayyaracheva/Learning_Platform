using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Services.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HomeController : ControllerBase
	{
		private readonly IHomeService homeservice;

		public HomeController(IHomeService homeservice)
		{
			this.homeservice = homeservice;
		}

		[HttpGet("")]
		public async Task<IActionResult> PublicCourses()
	{
			var courses = await this.homeservice
				.GetPublicCoursrses()
				.Select(course => new StudentCourseViewModel(course))
				//.Select(p => new CourseResponseDTO(p))
				.ToListAsync();

			return this.StatusCode(StatusCodes.Status200OK, courses);
		}
	}

}

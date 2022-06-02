using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Contracts;
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
				.GetPublicCoursrsesAsync();

			return this.StatusCode(StatusCodes.Status200OK, courses);
		}
	}

}

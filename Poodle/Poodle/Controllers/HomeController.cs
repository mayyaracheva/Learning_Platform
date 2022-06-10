using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Poodle.Services.Contracts;
using Poodle.Web.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;
        public HomeController(ILogger<HomeController> logger, IHomeService homeservice)
		{
			_logger = logger;
			this.homeService = homeservice;
		}

		public async Task<IActionResult> Index()
        {
            var publicCourses = await this.homeService
                .GetPublicCoursrsesAsync()
                .Select(course => new CourseViewModel(course))
                .ToListAsync();

            return View(publicCourses);
        }

        public IActionResult About()
        {
            return this.View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

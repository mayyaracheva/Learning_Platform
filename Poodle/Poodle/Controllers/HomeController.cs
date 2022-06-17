using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using Poodle.Data.EntityModels;
using Poodle.Services.Constants;
using Poodle.Services.Contracts;
using Poodle.Web.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(ILogger<HomeController> logger, IHomeService homeservice, IWebHostEnvironment webHostEnvironment)
		{
			_logger = logger;
			this.homeService = homeservice;
            this.webHostEnvironment = webHostEnvironment;
        }

		public async Task<IActionResult> Index()
        {
            var publicCourses = await this.homeService
                .GetPublicCoursrsesAsync()
                .Select(course => new StudentCourseViewModel(course))
                .ToListAsync();

            return View(publicCourses);
        }

        public IActionResult About()
        {
            var newsApiClient = new NewsApiClient("77114c2a46ee4aa781a1286afe5986a6");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Jokes",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = DateTime.UtcNow.AddDays(-3)
            });

            if (articlesResponse.Status == Statuses.Ok)
            {
                return View(articlesResponse);
            }

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

        [HttpPost]
        public IActionResult SignUp(string email)
        {
            string fileName = ConstantsContainer.FILELOGGER_FILE;
            string logPath = Path.Combine(webHostEnvironment.WebRootPath, fileName);
            FileLogger fileLogger = new FileLogger(logPath);
            fileLogger.LogMessage(email);
            this.ViewData["SuccessMessage"] = "You successfully signed up to our newsletter";

            return this.View(viewName: "Success");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

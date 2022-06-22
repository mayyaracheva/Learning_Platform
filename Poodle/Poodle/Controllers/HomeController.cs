using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Web.Models;
using System;
using System.Diagnostics;
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
            HomeViewModel viewModel = new HomeViewModel();
            var publicCourses = await this.homeService
                .GetPublicCoursrses()
                .Select(course => new StudentCourseViewModel(course))
                .ToListAsync();
            viewModel.PublicCourses = publicCourses;
            var newsApiClient = new NewsApiClient("77114c2a46ee4aa781a1286afe5986a6");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "News",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = DateTime.UtcNow.AddDays(-1)
            });
            
            if (articlesResponse.Status == Statuses.Ok)
            {
                viewModel.Articles = articlesResponse;
            }
            return View(viewModel);
        }

        public IActionResult About()
        {
            return this.View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
                

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

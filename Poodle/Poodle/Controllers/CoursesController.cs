using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poodle.Data.EntityModels;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Web.Controllers
{
	public class CoursesController : Controller
	{
        private readonly ICoursesService coursesService;
        private readonly IHomeService homeService;
        private readonly IUsersService usersService;


        public CoursesController(ICoursesService coursesService,
								IHomeService homeService,
								IUsersService usersService)
		{
			this.coursesService = coursesService;
			this.homeService = homeService;
			this.usersService = usersService;
		}
		public async Task<IActionResult> Index([FromQuery] CourseQueryParameters filterParams)
        {
			if (!this.HttpContext.Session.Keys.Contains("CurrentUserEmail"))
			{
				return this.RedirectToAction("Login", "Auth");
			}
			this.ViewData["SortOrder"] = string.IsNullOrEmpty(filterParams.SortOrder) ? "desc" : "";
			var user = await GetUser();

			var publicCourses = await this.coursesService
				.GetAsync(user);
			return View(publicCourses);
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
				var user = await GetUser(); 
                var publicCourseViewModel = new PublicCourseViewModel(await this.coursesService.Get(id, user));

                return this.View(model: publicCourseViewModel);
            }
            catch (EntityNotFoundException)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = $"Course with id {id} does not exist.";
                return this.View("Error");
            }
        }

		public IActionResult Create()
		{
			CourseUpdateDTO viewModel = new CourseUpdateDTO();
			return this.View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CourseCreateDTO viewModel)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(viewModel);
			}

			var user = await GetUser();
			await this.coursesService.CreateAsync(viewModel, user);

			return this.RedirectToAction(actionName: "Index", controllerName: "Courses");
		}

		private async Task<User> GetUser()
        {
            var userEmail = this.HttpContext.Session.GetString("CurrentUserEmail");
            var user = await this.usersService.GetByEmail(userEmail);
            return user;
        }

    }
}

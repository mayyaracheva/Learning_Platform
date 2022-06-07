using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Data.EntityModels;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Web.Models;
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
		public async Task<IActionResult> Index()
        {
			var indexCourseViewModel = new IndexCourseViewModel
			{
				PublicCourses = await this.homeService.GetPublicCoursrsesAsync()
			};

			return View(indexCourseViewModel);
        }

        public IActionResult Details(int id)
        {
            try
            {

                var publicCourseViewModel = new PublicCourseViewModel(this.coursesService.Get(id));

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
			CourseDTO viewModel = new CourseDTO();
			return this.View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CourseDTO viewModel)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(viewModel);
			}

			var user = await GetUser();
			await this.coursesService.CreateAsync(viewModel, user);

			return this.RedirectToAction(actionName: "Index", controllerName: "Courses");
		}

		//public IActionResult Edit(int id)
		//{
		//    try
		//    {
		//        var postToEdit = this.postsService.Get(id);
		//        var viewModel = this.postMapper.ConvertToModel(postToEdit);
		//        return this.View(viewModel);
		//    }
		//    catch (EntityNotFoundException)
		//    {
		//        this.Response.StatusCode = StatusCodes.Status404NotFound;
		//        this.ViewData["Error"] = $"Post with id {id} does not exist.";
		//        return this.View("Error");
		//    }

		//}
		//[HttpPost]
		//public IActionResult Edit(int id, PostViewModel post)
		//{
		//    if (!this.ModelState.IsValid)
		//    {
		//        return this.View(post);
		//    }

		//    try
		//    {
		//        var postToEdit = this.postsService.Get(id);
		//        var postUpdateDto = this.postMapper.ConvertToDto(post);
		//        var user = GetUser();
		//        this.postsService.Update(user, postToEdit, postUpdateDto);
		//    }
		//    catch (EntityNotFoundException)
		//    {
		//        this.Response.StatusCode = StatusCodes.Status404NotFound;
		//        this.ViewData["ErrorMessage"] = $"Post with id {id} does not exist.";
		//        return this.View(viewName: "Error");
		//    }
		//    catch (UnauthorizedOperationException)
		//    {
		//        this.Response.StatusCode = StatusCodes.Status401Unauthorized;
		//        this.ViewData["ErrorMessage"] = "You are allowed to edit only personal posts";
		//        return this.View(viewName: "Error");
		//    }

		//    return this.RedirectToAction(actionName: "Index", controllerName: "Post");
		//}


		//public IActionResult Delete(int id)
		//{
		//    try
		//    {
		//        var postToDelete = this.postsService.Get(id);
		//        return this.View(postToDelete);
		//    }
		//    catch (EntityNotFoundException)
		//    {
		//        this.Response.StatusCode = StatusCodes.Status404NotFound;
		//        this.ViewData["Error"] = $"Post with id {id} does not exist.";
		//        return this.View("Error");
		//    }

		//}
		//[HttpPost]
		//public IActionResult DeletePost(int id)
		//{
		//    if (!this.ModelState.IsValid)
		//    {
		//        return this.View();
		//    }

		//    try
		//    {
		//        var postToDelete = this.postsService.Get(id);
		//        var user = GetUser();
		//        this.postsService.Delete(id, user.Id);
		//    }
		//    catch (EntityNotFoundException)
		//    {
		//        this.Response.StatusCode = StatusCodes.Status404NotFound;
		//        this.ViewData["error"] = $"Post with id {id} does not exist.";
		//        return this.View("Error");
		//    }

		//    return this.RedirectToAction(actionName: "Index", controllerName: "Post");
		//}

		private async Task<User> GetUser()
        {
            var userEmail = this.HttpContext.Session.GetString("CurrentUserEmail");
            var user = await this.usersService.GetByEmail(userEmail);
            return user;
        }

    }
}

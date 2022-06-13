using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Poodle.Data.EntityModels;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Web.Models;
using System;
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

			var publicCourses = await this.coursesService.Get(filterParams, user);
			return View(publicCourses);
		}


		public async Task<IActionResult> Details(int id)
		{
			if (!this.HttpContext.Session.Keys.Contains("CurrentUserEmail"))
			{
				return this.RedirectToAction("Login", "Auth");
			}
			try
			{
				var user = await GetUser();
				var course = await this.coursesService.Get(id, user);

				return this.View(model: course);
			}
			catch (EntityNotFoundException e)
			{
				return this.NotFound(e);
			}
		}

		public  IActionResult Create()
		{
			var model = new CourseDTO();
			return this.View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CourseDTO model)
		{
			
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}
			try
			{
				var user = await GetUser();
				await this.coursesService.CreateAsync(model, user);

				return this.RedirectToAction(actionName: "Index", controllerName: "Courses");
			}
			catch (UnauthorizedOperationException e)
			{
				return this.Unautorized(e);
			}
			catch (DuplicateEntityException e)
			{
				return this.DuplicateEntity(e);
			}
		}

		public async Task<IActionResult> Edit(int id)
		{
			if (!this.HttpContext.Session.Keys.Contains("CurrentUserEmail"))
			{
				return this.RedirectToAction("Login", "Auth");
			}
			try
			{
				var courseToEdit = await this.coursesService.ExistingCourseCheck(id);
				return this.View(new CourseDTO(courseToEdit));
			}
			catch (EntityNotFoundException e)
			{
				return this.NotFound(e);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, CourseDTO model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}

			try
			{
				var user =await GetUser();		
				await this.coursesService.UpdateAsync(id, user, model);
			}
			catch (UnauthorizedOperationException e)
			{
				return this.Unautorized(e);
			}

			return this.RedirectToAction(actionName: "Index", controllerName: "Courses");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View();
			}

			try
			{
				var user = await GetUser();
				await this.coursesService.DeleteAsync(id, user);
			}
			catch (EntityNotFoundException e)
			{
				return this.NotFound(e);
			}

			return this.RedirectToAction(actionName: "Index", controllerName: "Courses");
		}
		private async Task<User> GetUser()
		{
			var userEmail = this.HttpContext.Session.GetString("CurrentUserEmail");
			var user = await this.usersService.GetByEmail(userEmail);
			return user;
		}

		private IActionResult Unautorized(Exception e)
		{
			this.Response.StatusCode = StatusCodes.Status401Unauthorized;
			this.ViewData["ErrorMessage"] = e.Message;
			return this.View("Error");
		}
		private IActionResult DuplicateEntity(Exception e)
		{
			this.Response.StatusCode = StatusCodes.Status409Conflict;
			this.ViewData["ErrorMessage"] = e.Message;
			return this.View("Error");
		}
		private IActionResult NotFound(Exception e)
		{
			this.Response.StatusCode = StatusCodes.Status404NotFound;
			this.ViewData["ErrorMessage"] = e.Message;
			return this.View(viewName: "Error");
		}
	}
}

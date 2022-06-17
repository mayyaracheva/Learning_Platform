using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Poodle.Data.EntityModels;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Helpers;
using Poodle.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Web.Controllers
{
	public class CoursesController : Controller
	{
		private readonly ICoursesService coursesService;
		private readonly IHomeService homeService;
		private readonly IUsersService usersService;
		public static int courseId;


		public CoursesController(ICoursesService coursesService,
								IHomeService homeService,
								IUsersService usersService)
		{
			this.coursesService = coursesService;
			this.homeService = homeService;
			this.usersService = usersService;
		}
		public async Task<IActionResult> Index(CourseQueryParameters filterParams)
		{
			if (!this.HttpContext.Session.Keys.Contains("CurrentUserEmail"))
			{
				return this.RedirectToAction("Login", "Auth");
			}
			this.ViewData["SortOrder"] = string.IsNullOrEmpty(filterParams.SortOrder) ? "desc" : "";
			var user = await GetUser();

			if (AuthorizationHelper.IsStudent(user))
			{
				var studentCourses = await this.coursesService.StudentGetCourses(filterParams, user);
				return View(studentCourses);
			}

			var teacherCourses = await this.coursesService.TeacherGetCourses(filterParams, user);
			return View(teacherCourses);
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
				var course = await this.coursesService.EnrollStudentInPublicCourse(id, user);
				courseId = course.Id;
				if (AuthorizationHelper.IsStudent(user))
				{
					var model = new StudentCourseViewModel(course);
					return View(model);
				}
				else
				{
					var model = new TeacherCourseViewModel(course);
					return this.View(model);
				}
			}
			catch (EntityNotFoundException e)
			{
				return this.NotFound(e);
			}
		}

		public IActionResult Create()
		{
			if (!this.HttpContext.Session.Keys.Contains("CurrentUserEmail"))
			{
				return this.RedirectToAction("Login", "Auth");
			}
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
				var courseToEdit = await this.coursesService.GetExistingCourse(id);
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
				var user = await GetUser();
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

		public async Task<IActionResult> Enroll(int id)
		{
			if (!this.HttpContext.Session.Keys.Contains("CurrentUserEmail"))
			{
				return this.RedirectToAction("Login", "Auth");
			}
			try
			{
				var studentsNotEnrolled = await this.coursesService.GetUsersNotEnrolled(id);
				return this.View(studentsNotEnrolled);
			}
			catch (EntityNotFoundException e)
			{
				return this.NotFound(e);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Enroll(int id, string[] students)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View();
			}
			ViewBag.Message = "Selected Items:\\n";
			try
			{
				var user = await GetUser();
				var studentsNotEnrolled = await this.coursesService.GetUsersNotEnrolled(id);
				var enrolledStudents = new List<User>();

                foreach (var student in studentsNotEnrolled)
                {
                    if (students.Contains(student.Id.ToString()))
                    {
						enrolledStudents.Add(student);
						ViewBag.Message += string.Format("{0} {1}\\n", student.FirstName, student.LastName);
					}
                }
				await this.coursesService.EnrollStudentsInPrivateCourse(id, enrolledStudents);
			}
			catch (EntityNotFoundException e)
			{
				return this.NotFound(e);
			}

			return this.RedirectToAction(actionName: "Details", controllerName: "Courses", new { id = id });
		}

		[HttpPost]
		public async Task<IActionResult> Unenroll(int id)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View();
			}

			try
			{
				var user = await GetUser();
				await this.coursesService.Unenroll(id, user);
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

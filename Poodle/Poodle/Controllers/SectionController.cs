using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Poodle.Data.EntityModels;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using Poodle.Web.Helpers;
using Poodle.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Web.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionService sectionService;
        private readonly SectionMapper sectionMapper;
        private readonly AuthHelper authHelper;
        public static int currentSectionId;
      

        public SectionController(ISectionService sectionService, SectionMapper sectionMapper, AuthHelper authHelper)
        {
            this.sectionService = sectionService;
            this.sectionMapper = sectionMapper;
            this.authHelper = authHelper;
        }

        
        public async Task<IActionResult> Details(int id)
        {
            if (!this.HttpContext.Session.Keys.Contains("CurrentUserEmail"))
            {
                return this.RedirectToAction("Login", "Auth");
            }
            try
            {
                var section = await this.sectionService.GetById(id);
                return this.View(section);
            }
            catch (EntityNotFoundException)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = $"Section with id {id} does not exist.";

                return this.View(viewName: "Error");
            }

        }

        public async Task<IActionResult> CreateSection(int id)
        {
            //we get course ID fроm Course page when CreateSection button is clicked
            if (!this.HttpContext.Session.Keys.Contains("CurrentUserEmail"))
            {
                return this.RedirectToAction("Login", "Auth");
            }

            if (!this.HttpContext.Session.GetString("CurrentRole").Equals("teacher", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = $"You are not authorized to access this page.";
            }

            int currentCourseId = id;            
            await this.SectionsInCourse(currentCourseId); 
            return this.View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSection(SectionViewModel sectionModel, string selectedRank, string restriction)
        {
            if (!this.ModelState.IsValid)
            {
                this.RedirectToAction("CreateSection", "Section");
            }
            try
            {
                
                sectionModel.Rank = selectedRank;
                sectionModel.Restriction = restriction;
                int courseId = CoursesController.courseId;
                await this.sectionService.CreateSection(sectionModel, courseId);
                return this.RedirectToAction("Details", "Courses", new { id = CoursesController.courseId });
            }           
            catch (DuplicateEntityException)
            {
                this.Response.StatusCode = StatusCodes.Status400BadRequest;
                this.ViewData["ErrorMessage"] = $"Section with this name already exists.";

                return this.View(viewName: "Error");
            }
            
        }
            
           
        public async Task<IActionResult> Edit(int id)
        {
            if (!this.HttpContext.Session.Keys.Contains("CurrentUserEmail"))
            {
                return this.RedirectToAction("Login", "Auth");
            }

            if (!this.HttpContext.Session.GetString("CurrentRole").Equals("teacher", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = $"You are not authorized to access this page.";
            }
            
            var section = await this.sectionService.GetById(id);
            SectionViewModel sectionToBeUpdated = this.sectionMapper.ConvertToViewModel(section);
           
            await this.SectionsInCourse(section.CourseId);         
           
            return this.View(sectionToBeUpdated);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SectionViewModel viewModel, string selectedRank)
        {
            if (!this.ModelState.IsValid)
            {
                this.RedirectToAction("Edit", "Section");
            }
                        
            viewModel.Rank = selectedRank;            
            int courseId = CoursesController.courseId;
            await this.sectionService.UpdateSection(courseId, id, viewModel);
            return this.RedirectToAction("Details", "Courses", new { id = CoursesController.courseId });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.HttpContext.Session.Keys.Contains("CurrentUserEmail"))
            {
                return this.RedirectToAction("Login", "Auth");
            }

            if (!this.HttpContext.Session.GetString("CurrentRole").Equals("teacher", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = $"You are not authorized to access this page.";
            }

            var requester = await this.authHelper.TryGetUser(this.HttpContext.Session.GetString("CurrentUserEmail"));
            await this.sectionService.DeleteSection(id, requester);
            return this.RedirectToAction("Details", "Courses", new { id = CoursesController.courseId });
        }
        public IActionResult HideSection(int id)
        {           
            this.sectionService.RestrictSection(id, true);
            return this.RedirectToAction("Details", "Courses", new { id = CoursesController.courseId });
        }
        public IActionResult ShowSection(int id)
        {
            this.sectionService.RestrictSection(id, false);
            return this.RedirectToAction("Details", "Courses", new { id = CoursesController.courseId });
        }

        private async Task<List<string>> SectionsInCourse(int courseId)
        {
            //exclude current section for edit but not for create
            var sections = (await this.sectionService.GetByCourseId(courseId)).OrderBy(s => s.Rank).Select(section => section.Title = "before" + " " + section.Title).ToList();
            sections.Insert(0, "Last");
            sections.Insert(1, "First");
            ViewBag.Sections = sections;
            ViewBag.SectionsCount = sections.Count();
            return sections;
        }


    }
}

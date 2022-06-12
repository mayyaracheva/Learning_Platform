using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Poodle.Data.EntityModels;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
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
        public static int courseId;

        public SectionController(ISectionService sectionService)
        {
            this.sectionService = sectionService;
        }

        public async Task<IActionResult> Index(int id)
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
            if (!this.HttpContext.Session.Keys.Contains("CurrentUserEmail"))
            {
                return this.RedirectToAction("Login", "Auth");
            }
            

            var sections = (await this.sectionService.GetByCourseId(id)).OrderBy(s => s.Rank).Select(section => section.Title = "before" + " " + section.Title).ToList();
            sections.Insert(0, "Last");
            sections.Insert(1, "First");
            ViewBag.Sections = sections;
            ViewBag.SectionsCount = sections.Count();
            courseId = id;
            return this.View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSection(SectionCreateView sectionModel, string selectedRank, string restriction)
        {
            if (!this.ModelState.IsValid)
            {
                this.RedirectToAction("CreateSection", "Section");
            }
                        
            sectionModel.Rank = selectedRank;
            sectionModel.Restriction = restriction;
            await this.sectionService.CreateSection(sectionModel, courseId);
            return RedirectToAction("Index", "Courses");           

        }


    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Data.EntityModels;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Web.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionService sectionService;

        public SectionController(ISectionService sectionService)
        {
            this.sectionService = sectionService;
        }

        public async Task <IActionResult> Index(int id)
        {           
            var section = await this.sectionService.GetById(id);
            return this.View(section);
        }
               
        public IActionResult CreateSection(int id)
        {
            this.ViewData["CurrentCourse"] = id;
            return this.View();
        }


        [HttpPost]
        public IActionResult CreateSection(SectionCreateView sectionModel, int id)
        {
            throw new NotImplementedException();     
        }
    }
}

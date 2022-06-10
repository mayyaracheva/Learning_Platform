using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Web.Controllers
{
    public class TeacherController : Controller
    {


        public IActionResult CreateSection(SectionDto sectionModel)
        {
            return this.View(sectionModel);
        }

        //[HttpPost]
        //public IActionResult CreateSection()
        //{
        //    return this.View();
        //}
    }
}

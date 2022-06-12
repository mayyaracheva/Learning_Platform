using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Poodle.Data.EntityModels;
using Poodle.Services.Constants;
using Poodle.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Web.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        

        public NewsletterController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
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
    }
}

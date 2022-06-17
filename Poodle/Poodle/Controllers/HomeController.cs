using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using Poodle.Data.EntityModels;
using Poodle.Services.Constants;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Web.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            var publicCourses = await this.homeService
                .GetPublicCoursrsesAsync()
                .Select(course => new StudentCourseViewModel(course))
                .ToListAsync();

            return View(publicCourses);
        }

        public IActionResult About()
        {
            var newsApiClient = new NewsApiClient("77114c2a46ee4aa781a1286afe5986a6");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Jokes",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = DateTime.UtcNow.AddDays(-3)
            });

            if (articlesResponse.Status == Statuses.Ok)
            {
                return View(articlesResponse);
            }

            return this.View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Contact(SendMailDto sendMailDto)
        {
            if (!ModelState.IsValid) return this.View();

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("zarko.y@gmail.com");
                mail.To.Add("mayyaracheva@gmail.com");
                mail.Subject = "Your Inquiry to Poodle E-Learning";
                mail.IsBodyHtml = true;
                string content = "Name: " + sendMailDto.Name;
                content += "Email: " + sendMailDto.Email;
                content += "<br/> Message: " + sendMailDto.Content;
                mail.Body = content;
                //pass mail server address
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                NetworkCredential networkCredential = new NetworkCredential("zarko.y@gmail.com", "!Y7u5I9nK]");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587;//default port but anothe rone can be passed as well
                smtpClient.EnableSsl = true;//if ssl required needs to be enabled
                smtpClient.Send(mail);
                ModelState.Clear();
                this.ViewData["SuccessMessage"] = "Your inquiry is sent";
                return this.View(viewName: "Success");
            }
            catch (Exception e)
            {
                this.ViewData["ErrorMessage"] = e.Message;
                return this.View(viewName: "Error");
            }
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

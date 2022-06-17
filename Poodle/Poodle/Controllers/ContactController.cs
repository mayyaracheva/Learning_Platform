using Microsoft.AspNetCore.Mvc;
using Poodle.Web.Helpers;
using Poodle.Web.Models;

namespace Poodle.Web.Controllers
{
    //[Route("contact")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send(UserContactViewModel contact)
        {
            string content = "Name: " + contact.Name;
            content += "<br>Phone: " + contact.Phone;
            content += "<br>Content: " + contact.Content;
            if (MailHelper.Send(contact.Email, "Zahari.V.Yordanov@gmail.com", contact.Subject, content))
            {
                ViewBag.msg = "Success!";
            }
            else
            {
                ViewBag.msg = "Error";
            }
            return View("Index");
        }
    }
}

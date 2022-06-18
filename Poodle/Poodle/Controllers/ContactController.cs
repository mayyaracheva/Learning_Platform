using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Constants;
using Poodle.Web.Helpers;
using Poodle.Web.Models;

namespace Poodle.Web.Controllers
{
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
                this.ViewData["SuccessMessage"] = ConstantsContainer.EMAIL_SUCCESS;
            }
            return this.View(viewName: "Success");
        }
    }
}


using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Constants;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Web.Helpers;

namespace Poodle.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            this.subscriptionService = subscriptionService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(string email)
        {
            if (email == null)
            {
                this.RedirectToAction("Index", "Home");
            }

            try
            {
                await this.subscriptionService.Add(email);
                this.ViewData["SuccessMessage"] = ConstantsContainer.SUBSCRIPTION_SUCCESS;
                return this.View(viewName: "Success");
            }
            catch (DuplicateEntityException e)
            {
                this.ViewData["ErrorMessage"] = e.Message;
                return this.View(viewName: "Error");
            }
           
        }
    
        public async Task<IActionResult> Delete()
        {
            try
            {
                string email = this.HttpContext.Session.GetString("CurrentUserEmail");
                await this.subscriptionService.Delete(email);
                this.ViewData["SuccessMessage"] = ConstantsContainer.SUBSCRIPTION_REMOVED;
                return this.View(viewName: "Success");
            }
            catch (EntityNotFoundException e)
            {
                this.ViewData["ErrorMessage"] = e.Message;
                return this.View(viewName: "Error");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Send(NewsLetterModel newsletter)
        {
            var subscribers = await this.subscriptionService.GetAll();

            foreach (var item in subscribers)
            {
                MailHelper.Send("Zahari.V.Yordanov@gmail.com", item.EmailAddress, newsletter.Subject, newsletter.Body);
            }
            
            this.ViewData["SuccessMessage"] = "Newsletter sent to every one";
            return this.View(viewName: "Success");
        }
    }
}

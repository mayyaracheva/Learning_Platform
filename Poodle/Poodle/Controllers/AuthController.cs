using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Constants;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Web.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Poodle.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthHelper authHelper;       
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUsersService usersService;

        public AuthController(AuthHelper authHelper, IUsersService usersService, IWebHostEnvironment webHostEnvironment)
        {
            this.authHelper = authHelper;
            this.usersService = usersService;           
            this.webHostEnvironment = webHostEnvironment;
        }

        //GET: /auth/login
        public IActionResult Login()
        {
            var userLoginModel = new LoginDto();

            return this.View(userLoginModel);
        }

        //POST: /auth/login
        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email, Password")] LoginDto userLoginModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(userLoginModel);
            }

            try
            {
                var user = await this.authHelper.TryGetUser(userLoginModel.Email, userLoginModel.Password);
                this.HttpContext.Session.SetString("CurrentUserEmail", user.Email);
                this.HttpContext.Session.SetString("CurrentUserName", user.FirstName);
                this.HttpContext.Session.SetString("CurrentRole", user.Role.Name);
                this.HttpContext.Session.SetString("CurrentImage", user.Image.ImageUrl);
                return this.RedirectToAction("Index", "Home", user);
            }
            catch (UnauthorizedOperationException e)
            {
                this.ModelState.AddModelError("Email", e.Message);
                return this.View(userLoginModel);
            }
        }

        public IActionResult Register()
        {
            var userRegisterModel = new UserCreateDto();

            return this.View(userRegisterModel);
        }
       
        [HttpPost]
        public async Task<IActionResult> Register([Bind("FirstName, LastName, Email, Password, ImageFile")] UserCreateDto userRegisterModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(userRegisterModel);
            }

            try
            {
                if (userRegisterModel.ImageFile != null)
                {
                    string folder = "img";
                    folder += Guid.NewGuid().ToString() + "_" + userRegisterModel.ImageFile.FileName;
                    string imageUrl = "/" + folder;
                    string path = Path.Combine(webHostEnvironment.WebRootPath, folder);
                    await userRegisterModel.ImageFile.CopyToAsync(new FileStream(path, FileMode.Create));

                    var createdUser = await this.usersService.Create(userRegisterModel, imageUrl);

                    return this.RedirectToAction("Login");
                }
                else
                {
                    string imageUrl = ConstantsContainer.DEFAULT_IMAGEURL;
                    var createdUser = await this.usersService.Create(userRegisterModel, imageUrl);

                    return this.RedirectToAction("Login"); 
                }

            }
            catch
            {

                return this.View(userRegisterModel);
            }
                       

        }
       

        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("CurrentUserEmail");

            return this.RedirectToAction("Index", "Home");
        }
    }
}

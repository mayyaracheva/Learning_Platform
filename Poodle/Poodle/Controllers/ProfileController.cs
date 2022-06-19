using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Data.EntityModels;
using Poodle.Services.Constants;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Poodle.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUsersService usersService;
        private readonly UserMapper userMapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProfileController(IUsersService usersService, IWebHostEnvironment webHostEnvironment, UserMapper userMapper)
        {
            this.usersService = usersService;
            this.webHostEnvironment = webHostEnvironment;
            this.userMapper = userMapper;
        }


        public async Task<IActionResult> Index()
        {
            UserUpdateDto userToBeUpdated = this.userMapper.ConvertToUpdateDto(await this.GetLoggedUser());
            return this.View(userToBeUpdated);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateDto userModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(userModel);
            }

            try
            {
                var loggedUser = await this.GetLoggedUser();

                //if any image is uploaded
                if (userModel.ImageFile != null)
                {
                    //check if user has a pic in the folder and delete it to add the new one
                    string currentUrl = loggedUser.Image.ImageUrl.Substring(1);
                    string path = Path.Combine(webHostEnvironment.WebRootPath, currentUrl);
                    string defaultPath = Path.Combine(webHostEnvironment.WebRootPath, ConstantsContainer.DEFAULT_IMAGEURL.Substring(1));

                    if (System.IO.File.Exists(path) && path != defaultPath)
                    {
                        System.IO.File.Delete(path);
                    }

                    //upload new image
                    string folder = "img";
                    folder += "/" + Guid.NewGuid().ToString() + "_" + userModel.ImageFile.FileName;
                    string imageUrl = "/" + folder;
                    userModel.ImageUrl = imageUrl;
                    string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folder);
                    await userModel.ImageFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                    var updatedUser = await this.usersService.UpdateWeb(loggedUser.Id, userModel);

                    //update user in Context
                    this.ResetContext(updatedUser);
                    this.ViewData["SuccessMessage"] = "You updated your profile successfully";
                    return this.View(viewName: "Success");
                }
                else
                {
                    var updatedUser = await this.usersService.UpdateWeb(loggedUser.Id, userModel);
                    //update user in Context
                    this.ResetContext(updatedUser);
                    this.ViewData["SuccessMessage"] = "You updated your profile successfully";
                    return this.View(viewName: "Success");
                }
            }
            catch (DuplicateEntityException)
            {
                this.ModelState.AddModelError("Email", ConstantsContainer.USER_EXISTS);
                return this.RedirectToAction(actionName: "Index", controllerName: "Profile");
            }


        }

        private void ResetContext(User user)
        {
            this.HttpContext.Session.SetString("CurrentImage", user.Image.ImageUrl);
            this.HttpContext.Session.SetString("CurrentUserEmail", user.Email);
            this.HttpContext.Session.SetString("CurrentUserName", user.FirstName);
        }

        private async Task<User> GetLoggedUser()
        {
            var userEmail = this.HttpContext.Session.GetString("CurrentUserEmail");
            var user = await this.usersService.GetByEmail(userEmail);

            if (user == null)
            {
                this.RedirectToAction("Login", "Auth");
            }
            return user;
        }

    }
}

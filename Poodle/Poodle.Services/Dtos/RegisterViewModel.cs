using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Poodle.Services.Dtos
{
    public class RegisterViewModel : UserCreateDto
    {        

        [Display(Name = "Profile Photo")]
        public IFormFile ImageFile { get; set; }
    }
}

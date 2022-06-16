using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Services.Dtos
{
    public class RegisterViewModel : UserCreateDto
    {        

        [Display(Name = "Profile Photo")]
        public IFormFile ImageFile { get; set; }
    }
}

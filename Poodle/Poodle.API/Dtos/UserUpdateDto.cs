using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Services.Dtos
{
    public class UserUpdateDto
    {
        public string FirstName { get; set; }
      
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ImageUrl { get; set; }
    }
}

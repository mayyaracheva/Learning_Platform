
using System.ComponentModel.DataAnnotations;

namespace Poodle.Web.Models
{
    public class UserContactViewModel
    {
        public string Name { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }

        public string Content { get; set; }
    }
}

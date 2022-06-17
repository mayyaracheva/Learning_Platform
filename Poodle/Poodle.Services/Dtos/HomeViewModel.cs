using NewsAPI.Models;
using Poodle.Web.Models;
using System.Collections.Generic;

namespace Poodle.Services.Dtos
{
    public class HomeViewModel
    {

        public List<StudentCourseViewModel> PublicCourses { get; set; }
        public ArticlesResult Articles { get; set; }
    }
}

using Poodle.Data.EntityModels;
using Poodle.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Poodle.Services.Dtos
{
    public class TeacherCourseViewModel : StudentCourseViewModel
    {
        public TeacherCourseViewModel()
        {

        }

        public TeacherCourseViewModel(Course course)
        {
            this.CourseId = course.Id;
            this.Title = course.Title;
            this.Description = course.Description;
            this.UsersCount = course.Users.Count;
            this.PhotoURL = course.PhotoURL;
            this.CategoryId = course.CategoryId;
            this.Users = course.Users;
            this.Sections = course.Sections;
            this.CategoryName = course.Category.Name;
        }

        public string CategoryName { get; set; }
        public IList<User> Users { get; set; }
    }
}

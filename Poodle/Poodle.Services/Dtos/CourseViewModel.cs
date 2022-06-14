using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using System.Net;
using System.Text.RegularExpressions;

namespace Poodle.Web.Models
{
	public class CourseViewModel : CourseDTO
	{
		public CourseViewModel()
		{

		}
		public CourseViewModel(Course course)
		{
			this.CourseId = course.Id;
			this.Title = course.Title;
			this.Description = course.Description;
			this.UsersCount = course.Users.Count;
			this.PhotoURL = course.PhotoURL;
			this.CategoryId = course.CategoryId;
		}

		public int CourseId { get; set; }
		public string ShortDescription
		{
			get
			{
				var content = WebUtility.HtmlDecode(Regex.Replace(this.Description, @"<[^>]+>", string.Empty));
				return content.Length > 80
						? content.Substring(0, 80) + "..."
						: content;
			}
		}
		public int UsersCount { get; set; }

	}
}

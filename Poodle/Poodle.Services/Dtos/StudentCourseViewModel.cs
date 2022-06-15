using Ganss.XSS;
using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Poodle.Web.Models
{
	public class StudentCourseViewModel : CourseDTO
	{
		public StudentCourseViewModel()
		{

		}
		public StudentCourseViewModel(Course course)
		{
			this.CourseId = course.Id;
			this.Title = course.Title;
			this.Description = course.Description;
			this.UsersCount = course.Users.Count;
			this.PhotoURL = course.PhotoURL;
			this.CategoryId = course.CategoryId;
			this.Sections = course.Sections;
		}

		public int CourseId { get; set; }

		public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Description);
		public string ShortDescription
		{
			get
			{
				var content = WebUtility.HtmlDecode(Regex.Replace(this.SanitizedContent, @"<[^>]+>", string.Empty));
				return content.Length > 80
						? content.Substring(0, 80) + "..."
						: content;
			}
		}
		public int UsersCount { get; set; }
		public ICollection<Section> Sections { get; set; }
	}
}

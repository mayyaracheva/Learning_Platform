using Poodle.Services.Dtos;
using System.Collections.Generic;

namespace Poodle.Web.Models
{
	public class IndexCourseViewModel
	{
		public IndexCourseViewModel()
		{

		}
		public string CourseTitle { get; set; }
		public string CourseDescription { get; set; }

		public IList<CourseResponseDTO> PublicCourses { get; set; }
	}
}

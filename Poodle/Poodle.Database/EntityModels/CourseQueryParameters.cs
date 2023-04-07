
using System.ComponentModel.DataAnnotations;

namespace Poodle.Data.EntityModels
{
	public class CourseQueryParameters
	{
		public string Title { get; set; }
		public string Category { get; set; }
		public string SortBy { get; set; }
		public string SortOrder { get; set; }

		[Range(1, int.MaxValue)]
		public int PageNumber { get; set; } = 1;

		[Range(1, int.MaxValue)]
		public int PageSize { get; set; } = 15;

		//public bool NoQueryParameters
		//{
		//	get
		//	{
		//		if (string.IsNullOrEmpty(Title) &&
		//			string.IsNullOrEmpty(Category) &&
		//			string.IsNullOrEmpty(SortBy) &&
		//			string.IsNullOrEmpty(SortOrder))
		//			return true;

		//		return false;
		//	}
		//}
	}
}

using Poodle.Data.EntityModels.Contracts;

namespace Poodle.Data.EntityModels
{
	public class Section : Entity, IDeletable
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public bool IsDeleted { get; set; }

		//public int Rank { get; set; }
		//public DateTime AvailableBy {get; set;}

		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}

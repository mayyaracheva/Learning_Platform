namespace Poodle.Data.EntityModels
{
	public class Section : Entity
	{
		public int Id { get; set; }
		public string Title { get; set; }		

		public int CourseId { get; set; }
		public Course Course { get; set; }

	}
}

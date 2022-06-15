using Poodle.Data.EntityModels.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace Poodle.Data.EntityModels
{
	public class Section : Entity, IDeletable
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public bool IsDeleted { get; set; }
		public bool IsRestricted { get; set; }
		public int Rank { get; set; }
		public bool IsEmbeded { get; set; }
		
		[DataType(DataType.Date)]
		public DateTime? UnlockOn { get; set; }
		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}

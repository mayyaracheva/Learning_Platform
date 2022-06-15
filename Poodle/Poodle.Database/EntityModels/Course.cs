using Ganss.XSS;
using Poodle.Data.EntityModels.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poodle.Data.EntityModels
{
	public class Course : Entity, IDeletable
	{
		public int Id { get; set; } 
		public string Title { get; set; }
		public string Description { get; set; }
		public string PhotoURL { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }

		//a course can have many sections and many users
		public ICollection<Section> Sections { get; set; }
		public List<User> Users { get; set; }
        public bool IsDeleted { get ; set ; }
    }
}

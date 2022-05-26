using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Data.EntityModels
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        //Navigation properties
        //foreign key, one user can have one profile photo and vice versa
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

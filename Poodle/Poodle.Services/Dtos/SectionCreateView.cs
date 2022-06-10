using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Services.Dtos
{
    public class SectionCreateView
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int Rank { get; set; }

        public bool IsRestricted { get; set; }





    }
}


using Poodle.Services.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Services.Dtos
{
    public class SectionViewModel : SectionDto
    {       
        public string Rank { get; set; }

        [Display(Name = "Restrict View")]
        public string Restriction { get; set; }

        [Display(Name = "Unlock on")]
        [DataType(DataType.Date)]
        public DateTime? Unlock { get; set; }

        public bool IsEmbeded { get; set; }

        
    }
}

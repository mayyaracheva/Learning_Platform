

using System;
using System.ComponentModel.DataAnnotations;


namespace Poodle.Services.Dtos
{
    public class SectionViewModel : SectionDto
    {       
        public string Rank { get; set; }

        [Display(Name = "Restrict View")]
        public string Restriction { get; set; }

        public bool IsRestricted { get; set; }

        [Display(Name = "Unlock on")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? UnlockOn { get; set; }

        public bool IsEmbeded { get; set; }

        public override bool Equals(object obj)
        {
            SectionViewModel otherSection = obj as SectionViewModel;
            if (otherSection != null)
            {
                return this.Content == otherSection.Content && this.Title == otherSection.Title && this.IsEmbeded == otherSection.IsEmbeded;
            }
            else
            {
                return false;
            }
           
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using Poodle.Web.Models;

namespace Poodle.Services.Mappers
{
    public class SectionMapper

    {       

        public Section ConvertToModel(SectionDto sectionDto)
        {
            Section section = new Section();
            section.Content = sectionDto.Content;
            section.Title = sectionDto.Title;            
            return section;
        }

        public Section ConvertToModel(SectionViewModel sectionDto)
        {
            Section section = new Section();
            section.Content = sectionDto.Content;
            section.Title = sectionDto.Title;

            if (sectionDto.Restriction == "true")
            {
                section.IsRestricted = true;
            }
            else
            {
                section.IsRestricted = false;
            }
            
            return section;
        }

        public SectionDto ConvertToDto(Section sectionModel)
        {
            SectionDto section = new SectionDto();
            sectionModel.Content = section.Content;
            sectionModel.Title = section.Title;            
            return section;
        }

        public SectionViewModel ConvertToViewModel(Section sectionModel)
        {
            SectionViewModel section = new SectionViewModel();
            section.Content = sectionModel.Content;
            section.Title = sectionModel.Title;
            section.IsRestricted = sectionModel.IsRestricted;
            if (sectionModel.IsRestricted)
            {
                section.Restriction = "true";
                
            }
            else
            {
                section.Restriction = "false";
            }            

            return section;
        }

    }
}

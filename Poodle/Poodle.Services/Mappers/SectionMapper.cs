using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Services.Mappers
{
    public class SectionMapper
    {
        public Section ConvertToModel(SectionDto sectionDto)
        {
            Section section = new Section();
            section.Content = sectionDto.Content;
            section.Title = sectionDto.Title;
            section.Rank = sectionDto.Rank;
            return section;
        }

        public SectionDto ConvertToDto(Section sectionModel)
        {
            SectionDto section = new SectionDto();
            sectionModel.Content = section.Content;
            sectionModel.Title = section.Title;
            sectionModel.Rank = section.Rank;
            return section;
        }
    }
}

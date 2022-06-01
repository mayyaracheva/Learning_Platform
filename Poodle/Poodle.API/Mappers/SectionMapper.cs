using Poodle.Services.Dtos;
using Poodle.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Services.Mappers
{
    public class SectionMapper
    {
        public Section ConvertToModel(SectionCreateDto sectionCreateDto)
        {
            Section newSection = new Section();
            newSection.Title = sectionCreateDto.Title;
            newSection.Content = sectionCreateDto.Content;
            newSection.CourseId = sectionCreateDto.CourseId;
            return newSection;            

        }
    }
}

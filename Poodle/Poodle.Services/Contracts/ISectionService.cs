﻿

using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using Poodle.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
    public interface ISectionService
    {
        Task<List<Section>> GetAll();
        Task<Section> GetById(int id);
        Task<List<Section>> GetByCourseId(int id);
        Task<List<SectionDto>> GetByCourseId(int id, User requester);
        Task<SectionDto> CreateSection(int id, SectionDto sectionDto, User requester);
        Task<SectionDto> CreateSection(SectionCreateView sectionDto, int courseId);
        Task<int> DeleteSection(int sectionId, User requester);
        Task<SectionDto> UpdateSection(int courseId, int sectionId, SectionDto sectionDto, User requester);
    }
}

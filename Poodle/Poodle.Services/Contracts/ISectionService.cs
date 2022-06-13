

using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
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
        Task<SectionDto> CreateSection(SectionDto sectionDto, int courseId, User requester);
        Task<SectionDto> CreateSection(SectionViewModel sectionDto, int courseId, User requester);
        Task<int> DeleteSection(int sectionId, User requester);
        Task<SectionDto> UpdateSection(int courseId, int sectionId, SectionViewModel sectionDto, User requester);
        Task<SectionDto> UpdateSection(int courseId, int sectionId, SectionDto sectionDto, User requester);
        Task<Section> RestrictSection(int id, bool isRestricted);
    }
}

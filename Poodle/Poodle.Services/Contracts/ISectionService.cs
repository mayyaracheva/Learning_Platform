

using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
    public interface ISectionService
    {
        Task<List<Section>> GetAll();
        Task<List<Section>> GetByCourseId(int id);
        Task<List<SectionDto>> GetByCourseId(int id, User requester);
        Task<SectionDto> Create(int id, SectionDto sectionDto, User requester);
        Task<int> Delete(int sectionId, User requester);
        Task<SectionDto> Update(int courseId, int sectionId, SectionDto sectionDto, User requester);
    }
}

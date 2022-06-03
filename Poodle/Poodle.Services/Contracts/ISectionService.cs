

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
        Task<List<SectionDto>> GetByCourseId(int id, string email, string password);
        Task<SectionDto> Create(int id, SectionDto sectionDto, string email, string password);
        void EnrollSingleStudent(int studentId, int courseId);

        void EnrollMultipleStudents(List<int> studentIds, int courseId);
        

    }
}

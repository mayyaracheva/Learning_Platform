

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
        Task<List<SectionResponseDto>> GetByCourseId(int id, string email, string password);
        Task<int> Create(int id, string title, string content, string email, string password);
        void EnrollSingleStudent(int studentId, int courseId);

        void EnrollMultipleStudents(List<int> studentIds, int courseId);
        

    }
}

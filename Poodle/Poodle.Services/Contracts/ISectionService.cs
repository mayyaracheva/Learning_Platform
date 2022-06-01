

using Poodle.Data.EntityModels;
using System.Collections.Generic;

namespace Poodle.Services.Contracts
{
    public interface ISectionService
    {
        List<Section> GetByCourseId(int id, string email, string password);
        Section Create(Section sectionModel);
        void EnrollSingleStudent(int studentId, int courseId);

        void EnrollMultipleStudents(List<int> studentIds, int courseId);
        

    }
}

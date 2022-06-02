using Poodle.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Repositories.Contracts
{
    public interface ISectionRepository
    {
        IQueryable<Section> GetAll();
        IQueryable<Section> GetByCourseId(int id);
        Task<int> Create(Section sectionModel);
        void EnrollSingleStudent(int studentId, int courseId);
        void EnrollMultipleStudents(List<int> studentIds, int courseId);

    }
}

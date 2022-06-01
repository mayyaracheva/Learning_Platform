using Microsoft.EntityFrameworkCore;
using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ApplicationContext context;

        public SectionRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IQueryable<Section> GetAll()
        {
            return context.Sections
                .Include(s => s.Course);
                
        }
        public IQueryable<Section> GetByCourseId(int id)
        {
            return this.GetAll().Where(s => s.CourseId == id);
        }

        public Section Create(Section sectionModel)
        {
            throw new NotImplementedException();
        }

        public void EnrollMultipleStudents(List<int> studentIds, int courseId)
        {
            throw new NotImplementedException();
        }

        public void EnrollSingleStudent(int studentId, int courseId)
        {
            throw new NotImplementedException();
        }

        
    }
}

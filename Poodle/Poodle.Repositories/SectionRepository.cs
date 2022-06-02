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
            => context.Sections;
                        
        public IQueryable<Section> GetByCourseId(int id)        
            => this.GetAll().Where(s => s.CourseId == id);
        
        public async Task<int> Create(Section sectionModel)
        {     
            var createdSection = await this.context.Sections.AddAsync(sectionModel);
            await this.context.SaveChangesAsync();
            return createdSection.Entity.Id;
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

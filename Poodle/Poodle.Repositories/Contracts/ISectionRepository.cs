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
        Task<Section> Create(Section sectionModel, int courseId);
        Task<int> Delete(Section sectionToDelete);
        Task<Section> Update(int id, Section sectionDto);
        Task<Section> RestrictSection(int id, bool isRestricted);

    }
}

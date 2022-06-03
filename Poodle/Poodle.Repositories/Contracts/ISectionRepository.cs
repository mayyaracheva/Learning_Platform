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
        Task<Section> Create(Section sectionModel);
        Task<int> Delete(Section sectionToDelete);
        Task<Section> Update(int id, Section sectionDto);

    }
}

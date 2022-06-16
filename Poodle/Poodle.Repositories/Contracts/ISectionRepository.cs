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
        Task<Section> UpdateFromApi(Section sectionToUpdate);
        Task<Section> UpdateFromView(Section sectionToUpdate);
        Task<Section> RestrictSection(Section sectionToUpdate);

    }
}

﻿
using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using System;
using System.Linq;
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
              

        public async Task<Section> Create(Section sectionModel, int courseId)
        {     
            var createdSection = await this.context.Sections.AddAsync(sectionModel);            
            await this.context.SaveChangesAsync();
            return createdSection.Entity;
        }
                

        public async Task<int> Delete(Section sectionToDelete)
        {
            this.context.Sections.Remove(sectionToDelete);
            await this.context.SaveChangesAsync();
            return sectionToDelete.Id;
        }

        public async Task<Section> UpdateFromApi(Section sectionToUpdate)
        {
            await this.context.SaveChangesAsync();
            return sectionToUpdate;
        }

        public async Task<Section> UpdateFromView(Section sectionToUpdate)
        {            
            await this.context.SaveChangesAsync();
            return sectionToUpdate;
        }


        public async Task<Section> RestrictSection(Section sectionToUpdate)
        {   
            await this.context.SaveChangesAsync();
            return sectionToUpdate;
        }

    }
}


using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using System;
using System.Collections.Generic;
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
         
        public async Task<Section> Create(Section sectionModel)
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

        public async Task<Section> Update(int id, Section sectionDto)
        {
            var sectionToUpdate = this.GetAll().Where(s => s.Id == id).FirstOrDefault();

            sectionToUpdate.Content = !string.IsNullOrEmpty(sectionDto.Content) ? sectionDto.Content : sectionToUpdate.Content;
            sectionToUpdate.Title = !string.IsNullOrEmpty(sectionDto.Title) ? sectionDto.Title : sectionToUpdate.Title;
            //sectionToUpdate.Rank = !string.IsNullOrEmpty(sectionDto.Rank) ? sectionDto.Rank : sectionToUpdate.Rank;
            sectionToUpdate.ModifiedOn = DateTime.Now;

            await this.context.SaveChangesAsync();

            return sectionToUpdate;
        }




    }
}

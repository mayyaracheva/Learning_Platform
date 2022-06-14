using Poodle.Services.Exceptions;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poodle.Services.Dtos;
using Poodle.Services.Mappers;
using Poodle.Services.Constants;
using Poodle.Services.Helpers;

namespace Poodle.Services
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository sectionRepository;
        private readonly SectionMapper sectionMapper;

        public SectionService(ISectionRepository sectionRepository, SectionMapper sectionMapper)
        {
            this.sectionRepository = sectionRepository;
            this.sectionMapper = sectionMapper;
        }

        public async Task<List<Section>> GetAll()
            => await this.sectionRepository.GetAll().Where(section => section.IsDeleted == false)
            .Include(s => s.Course)
            .ThenInclude(course => course.Category)
            .OrderBy(section => section.Rank)
            .ToListAsync();

        public async Task<Section> GetById(int id)
            => (await this.GetAll()).Where(Section => Section.Id == id).FirstOrDefault();

        public async Task<List<Section>> GetByCourseId(int id)
           => (await this.GetAll()).Where(Section => Section.CourseId == id).OrderBy(section => section.Rank).ToList();

        //sorted by Rank asc
        //the course page displays only the title which incl link to the section page
        //if section currently restricted, displays no link to page but restricted message instead
        //restricted not excl from DB pull as we need to replace their title with restricted message

        public async Task<List<SectionDto>> GetByCourseId(int courseId, User requester)
        {

            var sections = await this.GetByCourseId(courseId);


            if (sections.Count == 0)
            {
                throw new EntityNotFoundException(ConstantsContainer.SECTIONS_NOT_FOUND);
            }

            List<SectionDto> nonRestrictedSections = sections
               .Where(s => s.IsRestricted == false).Select(s => new SectionDto { Title = s.Title, Content = s.Content })               
               .ToList();

            List<SectionDto> restrictedSections = new List<SectionDto>();
            if (requester.Role.Name.Equals("Teacher", StringComparison.InvariantCultureIgnoreCase))
            {
                restrictedSections = sections
                .Where(s => s.IsRestricted == true)
                .Select(s => new SectionDto { Title = s.Title + " " + ConstantsContainer.RESTRICTED_SECTION_TITLE, Content = s.Content })
                .ToList();
            }
            else
            {
                restrictedSections = sections
                .Where(s => s.IsRestricted == true)
                .Select(s => new SectionDto { Title = s.Title + ConstantsContainer.RESTRICTED_SECTION_TITLE })
                .ToList();
            }

            restrictedSections.AddRange(nonRestrictedSections);

            return restrictedSections.ToList();

        }


        //option to change the rank to any int not used by current section in the course
        //restriction option - by date, by user (only enrolled in current course), no restriction by default
        //configure as new page(by default) or embedded

        public async Task<SectionDto> CreateSection(SectionDto sectionDto, int courseId, User requester)
        {
            AuthorizationHelper.ValidateAccess(requester.Role.Name);

            var allSections = await this.GetAll();

            if (allSections.Any(s => s.Title == sectionDto.Title))
            {
                throw new DuplicateEntityException(ConstantsContainer.SECTION_EXISTS);
            }

            Section newSection = this.sectionMapper.ConvertToModel(sectionDto);
            newSection.CourseId = courseId;
            newSection.IsRestricted = false;
            newSection.CreatedOn = DateTime.UtcNow;
            newSection.ModifiedOn = DateTime.UtcNow;

            var sectionsInCourse = await this.GetByCourseId(courseId);
            var highestRank = sectionsInCourse.Select(s => s.Rank).Max();
            newSection.Rank = highestRank + 1;

            var createdSection = await this.sectionRepository.Create(newSection, courseId);
            return this.sectionMapper.ConvertToDto(createdSection);
        }

        public async Task<SectionDto> CreateSection(SectionViewModel sectionDto, int courseId)
        {

            var allSectionsInCourse = await this.GetByCourseId(courseId);

            if (allSectionsInCourse.Any(s => s.Title == sectionDto.Title))
            {
                throw new DuplicateEntityException(ConstantsContainer.SECTION_EXISTS);
            }

            Section newSection = this.sectionMapper.ConvertToModel(sectionDto);
            newSection.CourseId = courseId;
            newSection.CreatedOn = DateTime.UtcNow;
            newSection.ModifiedOn = DateTime.UtcNow;
            this.UpdateRanksOnCreate(sectionDto.Rank, newSection, allSectionsInCourse);

            var createdSection = await this.sectionRepository.Create(newSection, courseId);
            return this.sectionMapper.ConvertToDto(createdSection);
        }

        public async Task<int> DeleteSection(int sectionId, User requester)
        {
            var sectionToDelete = await this.GetById(sectionId);
            var sectionsInCourse = await this.GetByCourseId(sectionToDelete.CourseId);
            sectionsInCourse.Remove(sectionToDelete);

            for (int i = 0, x = 1; i < sectionsInCourse.Count; i++)
            {
                sectionsInCourse[i].Rank = x;
                x++;
            }
            return await this.sectionRepository.Delete(sectionToDelete);
            
        }

        public async Task<SectionDto> UpdateSection(int courseId, int sectionId, SectionDto sectionDto, User requester)
        {
            AuthorizationHelper.ValidateAccess(requester.Role.Name);
            var sectionToUpdate = await this.GetById(sectionId);

            sectionToUpdate.Content = !string.IsNullOrEmpty(sectionDto.Content) ? sectionDto.Content : sectionToUpdate.Content;
            sectionToUpdate.Title = !string.IsNullOrEmpty(sectionDto.Title) ? sectionDto.Title : sectionToUpdate.Title;
            sectionToUpdate.ModifiedOn = DateTime.Now;

            return this.sectionMapper.ConvertToDto(await this.sectionRepository.UpdateFromApi(sectionToUpdate));
        }

        public async Task<SectionDto> UpdateSection(int courseId, int sectionId, SectionViewModel sectionDto)
        {

            var sectionToUpdate = await this.GetById(sectionId);

            if (!sectionDto.Title.Equals(sectionToUpdate.Title))
            {
                sectionToUpdate.Title = sectionDto.Title;
            }

            if (!sectionDto.Content.Equals(sectionToUpdate.Content))
            {
                sectionToUpdate.Content = sectionDto.Content;
            }

            if (!sectionDto.Rank.Equals("NoChange"))
            {
                var allSectionsInCourse = await this.GetByCourseId(courseId);

                this.UpdateRanksOnEdit(sectionDto.Rank, sectionToUpdate, allSectionsInCourse);
            }

            sectionToUpdate.ModifiedOn = DateTime.Now;
            return this.sectionMapper.ConvertToDto(await this.sectionRepository.UpdateFromView(sectionToUpdate));
        }

        public async Task<Section> RestrictSection(int id, bool isRestricted)
        {
            return await this.sectionRepository.RestrictSection(id, isRestricted);
        }

        private void UpdateRanksOnCreate(string newRank, Section newSection, List<Section> allSectionsInCourse)
        {

            if (newRank.Equals("last", StringComparison.InvariantCultureIgnoreCase))
            {
                newSection.Rank = allSectionsInCourse.Select(s => s.Rank).Max() + 1;
            }
            else if (newRank.Equals("first", StringComparison.InvariantCultureIgnoreCase))
            {
                newSection.Rank = 1;
                //change all ranks +1 upon create
                for (int i = 0; i < allSectionsInCourse.Count; i++)
                {
                    allSectionsInCourse[i].Rank += 1;
                }
            }
            else
            {
                //take the rank of selected section and assign it to new section; all sections from this one after, rank + 1;
                string sectionTitle = newRank.Replace("before ", null);
                Section currentSection = allSectionsInCourse.Where(s => s.Title == sectionTitle).FirstOrDefault();
                newSection.Rank = currentSection.Rank;
                var sectionsToChange = allSectionsInCourse.Where(s => s.Rank >= newSection.Rank).ToList();
                for (int i = 0; i < sectionsToChange.Count; i++)
                {
                    sectionsToChange[i].Rank += 1;
                }

            }
        }

        private void UpdateRanksOnEdit(string newRank, Section sectionToUpdate, List<Section> allSectionsInCourse)
        {
            if (newRank.Equals("last", StringComparison.InvariantCultureIgnoreCase))
            {                
                sectionToUpdate.Rank = allSectionsInCourse.Select(s => s.Rank).Max();
                allSectionsInCourse.Remove(sectionToUpdate);
                for (int i = 0, x = 1; i < allSectionsInCourse.Count; i++)
                {
                    allSectionsInCourse[i].Rank = x;
                    x++;
                }
            }
            else if (newRank.Equals("first", StringComparison.InvariantCultureIgnoreCase))
            {
                sectionToUpdate.Rank = 1;
                //all rest change their rank 
                allSectionsInCourse.Remove(sectionToUpdate);
                for (int i = 0, x = 2; i < allSectionsInCourse.Count; i++)
                {
                    allSectionsInCourse[i].Rank = x;
                    x++;
                }
            }
            else
            {
                //take the rank of selected section and assign it to new section; all sections from this one after, rank + 1;
                string sectionTitle = newRank.Replace("before ", null);
                Section currentSection = allSectionsInCourse.Where(s => s.Title == sectionTitle).FirstOrDefault();
                sectionToUpdate.Rank = currentSection.Rank;
                var sectionsToChange = allSectionsInCourse.Where(s => s.Rank >= sectionToUpdate.Rank).ToList();
                for (int i = 0; i < sectionsToChange.Count; i++)
                {
                    sectionsToChange[i].Rank += 1;
                }

            }
        }


    }
}

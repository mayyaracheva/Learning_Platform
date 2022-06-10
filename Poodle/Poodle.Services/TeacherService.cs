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
    public class TeacherService : ITeacherService
    {
        private readonly ISectionRepository sectionRepository; 
        private readonly SectionMapper sectionMapper;
        

        public TeacherService(ISectionRepository sectionRepository, SectionMapper sectionMapper)
        {
            this.sectionRepository = sectionRepository;            
            this.sectionMapper = sectionMapper;
        }

        public async Task<List<Section>> GetAll()
            => await this.sectionRepository.GetAll().Where(section => section.IsDeleted == false)
            .Include(s => s.Course)  
            .ThenInclude(course => course.Category)
            .ToListAsync();

        public async Task<List<Section>> GetByCourseId(int id)
           => (await this.GetAll()).Where(Section => Section.CourseId == id).ToList();

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
               .Where(s => s.IsRestricted == false).Select(s => new SectionDto { Title = s.Title, Content = s.Content})               
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

        public async Task<SectionDto> CreateSection(int courseId, SectionDto sectionDto, User requester)
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

            var createdSection = await this.sectionRepository.Create(newSection);
            return this.sectionMapper.ConvertToDto(createdSection);
        }

        public async Task<int> DeleteSection(int sectionId, User requester)
        {
            AuthorizationHelper.ValidateAccess(requester.Role.Name);
            var sectionToDelete = (await this.GetAll()).Where(s => s.Id == sectionId).FirstOrDefault();
            return await this.sectionRepository.Delete(sectionToDelete);
        }

        public async Task<SectionDto> UpdateSection(int courseId, int sectionId, SectionDto sectionDto, User requester)
        {
            AuthorizationHelper.ValidateAccess(requester.Role.Name);
            var sectionsInCourse = (await this.GetByCourseId(courseId)).OrderBy(s => s.Rank).ToList();
           
            var section = this.sectionMapper.ConvertToModel(sectionDto);
            return this.sectionMapper.ConvertToDto(await this.sectionRepository.Update(sectionId, section));
        }

        









    }
}

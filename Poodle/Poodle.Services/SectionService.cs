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
        private readonly IUsersService usersService;
        private readonly ICoursesService coursesService;
        private readonly SectionMapper sectionMapper;
        

        public SectionService(ISectionRepository sectionRepository, IUsersService usersService, ICoursesService coursesService, SectionMapper sectionMapper)
        {
            this.sectionRepository = sectionRepository;
            this.usersService = usersService;
            this.coursesService = coursesService;
            this.sectionMapper = sectionMapper;
        }

        public async Task<List<Section>> GetAll()
            => await this.sectionRepository.GetAll()
            .Include(s => s.Course)            
            .ToListAsync();

        public async Task<List<Section>> GetByCourseId(int id)
           => await this.sectionRepository.GetAll()
           .Include(s => s.Course)         
           .ToListAsync();

        //sorted by Rank asc
        //the course page displays only the title which incl link to the section page
        //if section currently restricted, displays no link to page but restricted message instead
        //restricted not excl from DB pull as we need to replace their title with restricted message

        public async Task<List<SectionDto>> GetByCourseId(int id, User requester)
        {
            AuthorizationHelper.ValidateAccess(requester.Role.Name);

            var sections =  await this.sectionRepository.GetByCourseId(id)
                .Include(s => s.Course)
                .ThenInclude(c => c.Category)
                .ToListAsync();           
            

            if (sections.Count > 0)
            {
                List<SectionDto> nonRestrictedSections = sections
                .Where(s => s.IsRestricted == false)
                .Select(s => new SectionDto { Title = s.Title, Content = s.Content })
                .ToList();

                List<SectionDto> restrictedSections = sections
                    .Where(s => s.IsRestricted == true)
                    .Select(s => new SectionDto { Title = s.Title, Content = ConstantsContainer.RESTRICTED_SECTION_TITLE })
                    .ToList();

                restrictedSections.AddRange(nonRestrictedSections);
                var sortedSections = restrictedSections.OrderBy(s => s.Rank);
                return sortedSections.ToList();
            }
            else
            {
                throw new EntityNotFoundException(ConstantsContainer.SECTIONS_NOT_FOUND);
            }
            
            
        }

        

        //option to change the rank to any int not used by current section in the course
        //restriction option - by date, by user (only enrolled in current course), no restriction by default
        //configure as new page(by default) or embedded

        public async Task<SectionDto> Create(int id, SectionDto sectionDto, User requester)
        {            
            AuthorizationHelper.ValidateAccess(requester.Role.Name);

            var allSections = await this.GetAll();

            if (allSections.Any(s => s.Title == sectionDto.Title))
            {
                throw new DuplicateEntityException(ConstantsContainer.SECTION_EXISTS);
            }

            Section newSection = this.sectionMapper.ConvertToModel(sectionDto);

            newSection.CourseId = id;
            newSection.IsRestricted = false;            
            newSection.CreatedOn = DateTime.UtcNow;
            newSection.ModifiedOn = DateTime.UtcNow;            

            var sectionsInCourse = await this.GetByCourseId(id);

            if (sectionDto.Rank == 0)
            {
                var highestRank = sectionsInCourse.Select(s => s.Rank).Max();
                sectionDto.Rank = highestRank + 1;
            }
            else
            {
                newSection.Rank = sectionDto.Rank;
            }                  

            var createdSection = await this.sectionRepository.Create(newSection);
            return this.sectionMapper.ConvertToDto(createdSection);
        }

        public async Task<int> Delete(int sectionId, User requester)
        {
            AuthorizationHelper.ValidateAccess(requester.Role.Name);
            var sectionToDelete = (await this.GetAll()).Where(s => s.Id == sectionId).FirstOrDefault();
            return await this.sectionRepository.Delete(sectionToDelete);
        }   










        }
}

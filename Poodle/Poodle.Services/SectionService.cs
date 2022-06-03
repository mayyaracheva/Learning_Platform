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

namespace Poodle.Services
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository sectionRepository;
        private readonly IUsersService usersService;
        private readonly SectionMapper sectionMapper;
        

        public SectionService(ISectionRepository sectionRepository, IUsersService usersService, SectionMapper sectionMapper)
        {
            this.sectionRepository = sectionRepository;
            this.usersService = usersService;
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
        //restricted not excl as we need to replace their title with restricted message

        public async Task<List<SectionDto>> GetByCourseId(int id, string requesterEmail, string requesterPassword)
        {
            var sections =  await this.sectionRepository.GetByCourseId(id)
                .Include(s => s.Course)
                .ToListAsync();

            var requesterRole = await this.usersService.CheckAuthorization(requesterEmail, requesterPassword);

            if (requesterRole.Name.Equals("student", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new UnauthorizedOperationException("You do not have required access for this operation");
            }

            if (sections.Count > 0)
            {
                List<SectionDto> nonRestrictedSections = sections
                .Where(s => s.IsRestricted == false)
                .Select(s => new SectionDto { Title = s.Title, Content = s.Content })
                .ToList();

                List<SectionDto> restrictedSections = sections
                    .Where(s => s.IsRestricted == true)
                    .Select(s => new SectionDto { Title = s.Title, Content = "Restricted section" })
                    .ToList();

                restrictedSections.AddRange(nonRestrictedSections);
                var sortedSections = restrictedSections.OrderBy(s => s.Rank);
                return sortedSections.ToList();
            }
            else
            {
                throw new EntityNotFoundException("The course contains no sections");
            }
            
            
        }

        //set title (unique, check and throw dupl exc) and content, check for null OK
        //set rank to be == last section rank in the course + 1 OK
        //set isrestricted = false;OK

        //option to change the rank to any int not used by current section in the course
        //restriction option - by date, by user (only enrolled in current course), no restriction by default
        //configure as new page(by default) or embedded

        public async Task<SectionDto> Create(int id, SectionDto sectionDto, string requesterEmail, string requesterPassword)
        {
            
            var allSections = await this.GetAll();

            if (allSections.Any(s => s.Title == sectionDto.Title))
            {
                throw new DuplicateEntityException($"Section with title {sectionDto.Title} already exists");
            }

            Section newSection = this.sectionMapper.ConvertToModel(sectionDto);

            newSection.CourseId = id;
            newSection.IsRestricted = false;            
            newSection.CreatedOn = DateTime.UtcNow;
            newSection.ModifiedOn = DateTime.UtcNow;            

            var sectionsInCourse = await this.GetByCourseId(id);
            var highestRank = sectionsInCourse.Select(s => s.Rank).Max();
            sectionDto.Rank = highestRank + 1;            

            var createdSection = await this.sectionRepository.Create(newSection);
            return this.sectionMapper.ConvertToDto(createdSection);
        }

        //check: option only available for private courses
        //check: student must not be enrolled yet
        //check: option available to teachers only
        public void EnrollSingleStudent(int studentId, int courseId)
        {
            
            
            throw new NotImplementedException();
        }

        //check: option only available for private courses
        //check: students must not be enrolled yet
        //check: option available to teachers only
        public void EnrollMultipleStudents(List<int> studentIds, int courseId)
        {
           
            
            throw new NotImplementedException();
        }








    }
}

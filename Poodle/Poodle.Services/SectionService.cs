using Poodle.Services.Exceptions;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poodle.Services
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository sectionRepository;
        private readonly IUsersService usersService;

        public SectionService(ISectionRepository sectionRepository, IUsersService usersService)
        {
            this.sectionRepository = sectionRepository;
            this.usersService = usersService;
        }


        public List<Section> GetByCourseId(int id, string requesterEmail, string requesterPassword)
        {
            var sections =  this.sectionRepository.GetByCourseId(id).OrderBy(s => s.Rank).ToList();
            var requesterRole = this.usersService.CheckAuthorization(requesterEmail, requesterPassword);

            if (requesterRole.Name.Equals("student", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new UnauthorizedOperationException("You do not have required access for this operation");
            }

            if (sections.Count > 0)
            {
                return sections;
            }
            else
            {
                throw new EntityNotFoundException("The course contains no sections");
            }

            
            //sorted by Rank asc
            //the course page displays only the title which incl link to the section page
            //if section currently restricted, displays no link to page but restricted message instead
            //restricted not excl as we need to replace their title with restricted message
        }

        public Section Create(Section sectionModel)
        {
            //set title (unique, check and throw dupl exc) and content
            //set rank to be == last section rank in the course + 1
            //set isrestricted = false;

            //option to change the rank to any int not used by current section in the course
            //restriction option - by date, by user (only enrolled in current course), no restriction by default
            //configure as new page(by default) or embedded
            
            throw new NotImplementedException();
        }

        public void EnrollSingleStudent(int studentId, int courseId)
        {
            //check: option only available for private courses
            //check: student must not be enrolled yet
            //check: option available to teachers only
            //
            throw new NotImplementedException();
        }

        public void EnrollMultipleStudents(List<int> studentIds, int courseId)
        {
            //check: option only available for private courses
            //check: students must not be enrolled yet
            //check: option available to teachers only
            
            throw new NotImplementedException();
        }








    }
}

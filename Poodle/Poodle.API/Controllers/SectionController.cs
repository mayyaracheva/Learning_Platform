using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService sectionService;
        private readonly AuthenticationHelper authenticationHelper;

        public SectionController(ISectionService sectionService, AuthenticationHelper authenticationHelper)
        {
            this.sectionService = sectionService;
            this.authenticationHelper = authenticationHelper;
        }

		[HttpGet("")]
		public IActionResult Get([FromQuery] int courseId, [FromHeader] string email, [FromHeader] string password)
		{
			//only teacher set to be authorized to get all sections
			//authorization checked in services
			try
			{
				this.authenticationHelper.TryGetUser(email, password);
				var sections = this.sectionService.GetByCourseId(courseId, email, password);
				List<SectionResponseDto> nonRestrictedSections = sections
					.Where(s => s.IsRestricted == false)
					.Select(s => new SectionResponseDto { Title = s.Title, Content = s.Content })
					.ToList();

				List<SectionResponseDto> restrictedSections = sections
					.Where(s => s.IsRestricted == true)
					.Select(s => new SectionResponseDto { Title = s.Title, Content = "Restricted section" })
					.ToList();

				
				restrictedSections.AddRange(nonRestrictedSections);
				var sortedSections = restrictedSections.OrderBy(s => s.Rank);

				return this.StatusCode(StatusCodes.Status200OK, sortedSections);
			}
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}

		}


	}
}

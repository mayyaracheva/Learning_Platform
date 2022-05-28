using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.API.Dtos;
using Poodle.API.Exceptions;
using Poodle.API.Mappers;
using Poodle.Services.Contracts;
using Poodle.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        
        private readonly UserMapper usermapper;
        private readonly IUsersService userservice;

        public UsersController(UserMapper usermapper, IUsersService userservice)
        {            
            this.usermapper = usermapper;
            this.userservice = userservice;
        }

		[HttpGet("")]
		public IActionResult Get([FromHeader] string email, [FromHeader] string password)
		{

			try
			{				
				List<UserResponseDto> users = this.userservice.Get(email, password).Select(u =>  usermapper.ConvertToDto(u)).ToList();
				return this.StatusCode(StatusCodes.Status200OK, users);
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

		[HttpGet("{id}")]
		public IActionResult GetById(int id, [FromHeader] string email, [FromHeader] string password)
		{
			try
			{				
				var user = this.userservice.Get(id, email, password);
				var userToDisplay = this.usermapper.ConvertToDto(user);

				return this.StatusCode(StatusCodes.Status200OK, userToDisplay);
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

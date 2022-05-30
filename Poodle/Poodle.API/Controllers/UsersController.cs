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
        
        private readonly UserMapper userMapper;
        private readonly IUsersService usersService;

        public UsersController(UserMapper userMapper, IUsersService usersService)
        {            
            this.userMapper = userMapper;
            this.usersService = usersService;
        }

		[HttpGet("")]
		public IActionResult Get([FromHeader] string email, [FromHeader] string password)
		{
			try
			{				
				List<UserResponseDto> users = this.usersService.GetAll(email, password).Select(u =>  userMapper.ConvertToDto(u)).ToList();
				return this.StatusCode(StatusCodes.Status200OK, users);
			}			
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id, [FromHeader] string email, [FromHeader] string password)
		{
			try
			{				
				var user = this.usersService.GetById(id, email, password);
				var userToDisplay = this.userMapper.ConvertToDto(user);

				return this.StatusCode(StatusCodes.Status200OK, userToDisplay);
			}
			
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromHeader] string email, [FromHeader] string password)
		{			

			if (id < 1)
			{
				return this.StatusCode(StatusCodes.Status400BadRequest, "Invalid Id");
			}

            try
            {
				this.usersService.Delete(id, email, password);
				return this.StatusCode(StatusCodes.Status200OK, "User deleted");
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

		[HttpPost("")]
		public IActionResult Create([FromBody] UserCreateDto userCreateDto, [FromQuery] string role)
        { 
			try
			{
				int roleId = this.usersService.GetRoleId(role);
				var newUser = this.userMapper.ConvertToModel(userCreateDto, roleId);
				var createdUser = this.usersService.Create(newUser, userCreateDto.ImageUrl);

				return this.StatusCode(StatusCodes.Status201Created, $"{createdUser.Role.Name} with id {createdUser.Id} created.");
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
			catch (DuplicateEntityException e)
			{
				return this.StatusCode(StatusCodes.Status406NotAcceptable, e.Message);
			}
		}
	}
}

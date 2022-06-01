using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using Poodle.Services.Contracts;
using Poodle.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poodle.Services.Helpers;

namespace Poodle.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        
        private readonly UserMapper userMapper;
		private readonly AuthenticationHelper authenticationHelper;
		private readonly IUsersService usersService;

        public UsersController(UserMapper userMapper, AuthenticationHelper authenticationHelper, IUsersService usersService)
        {            
            this.userMapper = userMapper;
            this.usersService = usersService;
			this.authenticationHelper = authenticationHelper;
        }

		[HttpGet("")]
		public IActionResult Get([FromHeader] string email, [FromHeader] string password)
		{
			//only teacher set to be authorized to get all users
			//authorization checked in services
			try
			{
				this.authenticationHelper.TryGetUser(email, password);
				List<UserResponseDto> users = this.usersService.GetAll(email, password).Select(u =>  userMapper.ConvertToDto(u)).ToList();
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
			//only teacher set to be authorized to get all user by id
			//authorization checked in services
			try
			{
				this.authenticationHelper.TryGetUser(email, password);
				var user = this.usersService.GetById(id, email, password);
				var userToDisplay = this.userMapper.ConvertToDto(user);

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

		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromHeader] string email, [FromHeader] string password)
		{       
			//only teacher set to be authorized to delete users
			//authorization checked in services	

			if (id < 1)
			{
				return this.StatusCode(StatusCodes.Status400BadRequest, "Invalid Id");
			}

            try
            {
				this.authenticationHelper.TryGetUser(email, password);
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
		public IActionResult Create([FromBody] UserCreateDto userCreateDto)
        { 
			//all newly created users are students by default
			try
			{				
				var newUser = this.userMapper.ConvertToModel(userCreateDto);
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

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] UserUpdateDto userUpdateDto, [FromHeader] string email, [FromHeader] string password)
        {
			//authentication check in Api, if user trying to make the update exists
			//authorization check (if user trying to make the update is same one, in services)
            try
            {
				this.authenticationHelper.TryGetUser(email, password);               
				this.usersService.Update(id, userUpdateDto.FirstName, userUpdateDto.LastName, userUpdateDto.Password, userUpdateDto.Email, userUpdateDto.ImageUrl, email, password);
				return this.StatusCode(StatusCodes.Status200OK, "User has been updated");
			}			
			catch (UnauthorizedOperationException e)
			{
				return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
			}
			catch (EntityNotFoundException e)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
			}
			catch (DuplicateEntityException e)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
			}
		}
	}
}

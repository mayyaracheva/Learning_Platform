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
        
        
		private readonly AuthenticationHelper authenticationHelper;
		private readonly IUsersService usersService;

        public UsersController(AuthenticationHelper authenticationHelper, IUsersService usersService)
        {  
            this.usersService = usersService;
			this.authenticationHelper = authenticationHelper;
        }

		[HttpGet("")]
		public async Task<IActionResult> Get([FromHeader] string email, [FromHeader] string password)
		{
			//only teacher set to be authorized to get all users
			//authorization checked in services
			try
			{
				await this.authenticationHelper.TryGetUser(email, password);
				var users = await this.usersService.GetAll(email, password);				
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
		public async Task<IActionResult> GetById(int id, [FromHeader] string email, [FromHeader] string password)
		{
			//only teacher set to be authorized to get all user by id
			//authorization checked in services
			try
			{
				await this.authenticationHelper.TryGetUser(email, password);
				var user = await this.usersService.GetById(id, email, password);				

				return this.StatusCode(StatusCodes.Status200OK, user);
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
		public async Task<IActionResult> Delete(int id, [FromHeader] string email, [FromHeader] string password)
		{       
			//only teacher set to be authorized to delete users
			//authorization checked in services	

			if (id < 1)
			{
				return this.StatusCode(StatusCodes.Status400BadRequest, "Invalid Id");
			}

            try
            {
				await this.authenticationHelper.TryGetUser(email, password);
				await this.usersService.Delete(id, email, password);
				return this.StatusCode(StatusCodes.Status200OK, $"User with id {id} deleted");
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
		public async Task<IActionResult> Create([FromBody] UserCreateDto userCreateDto)
        { 
			//all newly created users are students by default
			try
			{				
				var newUser = this.userMapper.ConvertToModel(userCreateDto);
				var createdUser = await this.usersService.Create(newUser, userCreateDto.ImageUrl);

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
		public async Task<IActionResult> Update(int id, [FromBody] UserUpdateDto userUpdateDto, [FromHeader] string email, [FromHeader] string password)
        {
			//authentication check in Api, if user trying to make the update exists
			//authorization check (if user trying to make the update is same one, in services)
            try
            {
				await this.authenticationHelper.TryGetUser(email, password);               
				await this.usersService.Update(id, userUpdateDto.FirstName, userUpdateDto.LastName, userUpdateDto.Password, userUpdateDto.Email, userUpdateDto.ImageUrl, email, password);
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

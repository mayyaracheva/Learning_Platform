using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Contracts;
using System.Threading.Tasks;
using Poodle.Services.Helpers;
using Poodle.Services.Constants;

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
				var requester = await this.authenticationHelper.TryGetUser(email, password);
				var users = await this.usersService.GetAll(requester);				
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
				var requester = await this.authenticationHelper.TryGetUser(email, password);
				var user = await this.usersService.GetById(id, requester);				

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
				return this.StatusCode(StatusCodes.Status400BadRequest, ConstantsContainer.USER_NOT_FOUND);
			}

            try
            {
				var requester = await this.authenticationHelper.TryGetUser(email, password);
				await this.usersService.Delete(id, requester);
				return this.StatusCode(StatusCodes.Status200OK, ConstantsContainer.USER_DELETED);
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
				
				var createdUser = await this.usersService.Create(userCreateDto, userCreateDto.ImageUrl);

				return this.StatusCode(StatusCodes.Status201Created, ConstantsContainer.USER_CREATED);
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
				var requester = await this.authenticationHelper.TryGetUser(email, password);               
				await this.usersService.UpdateApi(id, userUpdateDto, requester);
				return this.StatusCode(StatusCodes.Status200OK, ConstantsContainer.USER_UPDATED);
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

using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
    public interface IUsersService
    {
		Task<List<User>> GetAll();
		Task<User> GetById(int id);
		Task<List<UserResponseDto>> GetAll(User requester);
		Task<UserResponseDto> GetById(int id, User requester);
		Task<User> GetByEmail(string email);
		Task<List<User>> Get(UserQueryParameters filterParameters);
		//int GetRoleId(string roleName);		
		Task<User> Create(UserCreateDto user, string imageUrl);		
		Task<User> Update(int id, UserUpdateDto userUpdateDto, User requester);
		Task<int> Delete(int id, User requester);
		
		
	}
}

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
		Task<List<UserResponseDto>> GetAll(string requesterEmail, string requesterPassword);
		Task<UserResponseDto> GetById(int id, string requesterEmail, string requesterPassword);
		Task<User> GetByEmail(string email);
		Task<List<User>> Get(UserQueryParameters filterParameters);
		//int GetRoleId(string roleName);		
		Task<User> Create(User user, string imageUrl);		
		Task<User> Update(int id, string firstname, string lastname, string password, string email, string imageUrl, string requesterEmail, string requesterPassword);
		Task<int> Delete(int id, string requesterEmail, string requesterPassword);
		Task<Role> CheckAuthorization(string requesterEmail, string requesterPassword);
		
	}
}

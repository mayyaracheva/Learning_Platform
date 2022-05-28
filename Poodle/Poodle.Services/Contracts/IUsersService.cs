using Poodle.Data.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
    public interface IUsersService
    {
		List<User> Get(string requesterEmail, string requesterPassword);
		User Get(int id, string requesterEmail, string requesterPassword);
		User Get(string email, string requesterEmail, string requesterPassword);
		List<User> Get(UserQueryParameters filterParameters);
		Role GetRole(string email, string password);		
		Task<User> Create(User user, int roleId, string imageUrl);
		User Update(int id, User user);
		User Update(int id, User user, string imageUrl);
		User Delete(int id, bool isDeleted, string requesterEmail, string requesterPassword);

	}
}

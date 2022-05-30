using Poodle.Data.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
    public interface IUsersService
    {
		List<User> GetAll(string requesterEmail, string requesterPassword);
		User GetById(int id, string requesterEmail, string requesterPassword);
		User GetByEmail(string email, string requesterEmail, string requesterPassword);
		List<User> Get(UserQueryParameters filterParameters);			
		Task<User> Create(User user, int roleId, string imageUrl);
		User Update(int id, User user);
		User Update(int id, User user, string imageUrl);
		void Delete(int id, string requesterEmail, string requesterPassword);

	}
}

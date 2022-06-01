using Poodle.Data.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poodle.Services.Contracts
{
    public interface IUsersService
    {
		List<User> GetAll();
		User GetById(int id);
		List<User> GetAll(string requesterEmail, string requesterPassword);
		User GetById(int id, string requesterEmail, string requesterPassword);
		User GetByEmail(string email, string requesterEmail, string requesterPassword);
		List<User> Get(UserQueryParameters filterParameters);
		int GetRoleId(string roleName);		
		User Create(User user, string imageUrl);		
		User Update(int id, string firstname, string lastname, string password, string email, string imageUrl, string requesterEmail, string requesterPassword);
		void Delete(int id, string requesterEmail, string requesterPassword);
		Role CheckAuthorization(string requesterEmail, string requesterPassword);

		void CheckAuthorization(string email, string password);
	}
}

using Poodle.Data.EntityModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Repositories.Contracts
{
    public interface IUsersRepository
    {
		IQueryable<User> Get();		
		IQueryable<User> Get(int id);
		IQueryable<User> Get(string email);	
		
		Task<User> Create(User user, int roleId, string imageUrl);	
		User Update(int id, User user);
		User Update(int id, User user, string imageUrl);
		User Delete(int id, bool isDeleted);	









	}
}

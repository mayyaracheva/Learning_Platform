using Poodle.Data.EntityModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Repositories.Contracts
{
    public interface IUsersRepository
    {
		IQueryable<User> GetAll();		
		IQueryable<User> GetById(int id);
		IQueryable<User> GetByEmail(string email);	
		
		Task<User> Create(User user, int roleId, string imageUrl);	
		User Update(int id, User user);
		User Update(int id, User user, string imageUrl);
		void Delete(User userToDelete);









	}
}

using Poodle.Data.EntityModels;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Repositories.Contracts
{
    public interface IUsersRepository
    {
		IQueryable<User> GetAll();		
		IQueryable<User> GetById(int id);		
		IQueryable<Role> GetRoles();
		Task<User> Create(User user, string imageUrl);
		Task<User> Update(int id, User user, string imageUrl);		
		Task<int> Delete(User userToDelete);









	}
}

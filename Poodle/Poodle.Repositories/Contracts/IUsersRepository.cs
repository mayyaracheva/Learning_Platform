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
		IQueryable<Role> GetRoles();
		User Create(User user, string imageUrl);
		User Update(int id, string firstname, string lastname, string password, string email, string imageUrl);		
		int Delete(User userToDelete);









	}
}


using Poodle.Data.EntityModels;

namespace Poodle.Services.Helpers
{
	public class AuthorizationHelper
	{
        public bool IsTeacher(User user)
        {
            if (user.RoleId != 1)
            {
                return false;
            }
            return true;
        }
    }
}

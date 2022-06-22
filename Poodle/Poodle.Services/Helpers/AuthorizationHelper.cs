
using Poodle.Data.EntityModels;
using Poodle.Services.Constants;
using Poodle.Services.Exceptions;
using System;

namespace Poodle.Services.Helpers
{
	public static class AuthorizationHelper
	{
        public static void ValidateAccess(User user)
        {

            if (user.RoleId != ConstantsContainer.TEACHER_ID)
            {
                throw new UnauthorizedOperationException(ConstantsContainer.RESTRICTED_ACCESS);
            }
        }

        public static bool IsStudent(User user)
        {
            return user.Role.Name.Equals("student", StringComparison.CurrentCultureIgnoreCase);
        }

        
    }
}

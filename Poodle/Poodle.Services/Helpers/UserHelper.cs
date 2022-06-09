using Poodle.Data.EntityModels;
using Poodle.Services.Constants;
using Poodle.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Services.Helpers
{
    public static class UserHelper
    {
        public static User CheckIfUserExists(User user)
        {
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new EntityNotFoundException(ConstantsContainer.USER_NOT_FOUND);
            }
        }
    }
}

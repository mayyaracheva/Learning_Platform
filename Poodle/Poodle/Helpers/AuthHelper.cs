using Poodle.Data.EntityModels;
using Poodle.Services.Constants;
using Poodle.Services.Contracts;
using Poodle.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Web.Helpers
{
    public class AuthHelper
    {
        private readonly IUsersService usersService;

        public AuthHelper(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<User> TryGetUser(string email, string password)
        {
            var users = await this.usersService.GetAll();
            User user = users.Where(u => u.Email == email & u.Password == password).FirstOrDefault();

            //deleted users are excluded in GetAll method so such user will be returned as null

            if (user == null)
            {
                throw new UnauthorizedOperationException(ConstantsContainer.INVALID_CREDENTIALS);
            }

            return user;
        }

        public async Task<User> TryGetUser(string email)
        {
            var users = await this.usersService.GetAll();
            User user = users.Where(u => u.Email == email).FirstOrDefault();

            //deleted users are excluded in GetAll method so such user will be returned as null
            
            return user;
        }
    }
}

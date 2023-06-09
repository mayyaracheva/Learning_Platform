﻿using Poodle.Services.Exceptions;
using Poodle.Data.EntityModels;
using Poodle.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Poodle.Services.Constants;

namespace Poodle.Services.Helpers
{
    public class AuthenticationHelper
    {
        private readonly IUsersService usersService;

        public AuthenticationHelper(IUsersService usersService)
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


    }
}

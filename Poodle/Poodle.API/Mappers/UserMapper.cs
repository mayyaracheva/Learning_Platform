using Poodle.API.Dtos;
using Poodle.Data.EntityModels;
using Poodle.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.API.Mappers
{
    public class UserMapper
    {
        private readonly IUsersService usersService;

        public UserMapper(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public UserResponseDto ConvertToDto(User userModel)
        {
            UserResponseDto userToPresent = new UserResponseDto();
            userToPresent.FirstName = userModel.FirstName;
            userToPresent.LastName = userModel.LastName;
            userToPresent.Email = userModel.Email;
            userToPresent.Role = userModel.Role.Name;
            return userToPresent;
        }


    }
}

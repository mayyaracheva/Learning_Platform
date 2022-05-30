using Poodle.API.Dtos;
using Poodle.Data.EntityModels;
using Poodle.Services.Contracts;


namespace Poodle.API.Mappers
{
    public class UserMapper
    {
     

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

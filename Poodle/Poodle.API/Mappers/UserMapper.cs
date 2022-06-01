using Poodle.Services.Dtos;
using Poodle.Data.EntityModels;



namespace Poodle.Services.Mappers
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

        public User ConvertToModel(UserCreateDto userModel)
        {
            User newUser = new User();
            newUser.FirstName = userModel.FirstName;
            newUser.LastName = userModel.LastName;
            newUser.Email = userModel.Email;
            newUser.Password = userModel.Password;           
            newUser.RoleId = 2;
            return newUser;
        }


    }
}

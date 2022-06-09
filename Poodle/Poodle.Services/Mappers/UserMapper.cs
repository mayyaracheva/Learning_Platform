using Poodle.Data.EntityModels;
using Poodle.Services.Dtos;


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

        public UserUpdateDto ConvertToUpdateDto(User userModel)
        {
            UserUpdateDto userToPresent = new UserUpdateDto();
            userToPresent.FirstName = userModel.FirstName;
            userToPresent.LastName = userModel.LastName;
            userToPresent.Email = userModel.Email;
            userToPresent.Password = userModel.Password;
            userToPresent.ImageUrl = userModel.Image.ImageUrl;
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

        public User ConvertToModel(UserUpdateDto userModel)
        {
            User newUser = new User();
            newUser.FirstName = userModel.FirstName;
            newUser.LastName = userModel.LastName;
            newUser.Email = userModel.Email;
            newUser.Password = userModel.Password;  
            return newUser;
        }

    }
}

using Poodle.Services.Exceptions;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Poodle.Services.Dtos;
using Poodle.Services.Mappers;

namespace Poodle.Services.Services
{
    public class UsersService : IUsersService
    {
        public static string defaultImageUrl = "/Images/DefaultImage.jpg";
        private readonly IUsersRepository repository;
        private readonly UserMapper userMapper;

        public UsersService(IUsersRepository repository, UserMapper userMapper)
        {
            this.repository = repository;
            this.userMapper = userMapper;
        }

        public async Task<List<User>> GetAll()
        {
            return await this.repository.GetAll()
             .Include(u => u.Role)
             .Include(u => u.Image)
             .Include(u => u.Courses)
             .ToListAsync();
        }       
               
         
        public async Task<User> GetById(int id)
        {
            var user = await this.repository.GetById(id)
                .Include(u => u.Role)
                .Include(u => u.Image)
                .Include(u => u.Courses)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new EntityNotFoundException($"There is no user with id: {id}");
            }
        }

        public async Task<List<UserResponseDto>> GetAll(string requesterEmail, string requesterPassword)
        {
            Role requesterRole = await CheckAuthorization (requesterEmail, requesterPassword);

            if (requesterRole.Name.Equals("student", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new UnauthorizedOperationException("You do not have required access for this operation");
            }

            var users = await this.repository.GetAll()
                .Include(u => u.Role)
                .ToListAsync();
            var userResponseDtos = users.Select(u => userMapper.ConvertToDto(u)).ToList();
            return userResponseDtos;
        }

        public async Task<UserResponseDto> GetById(int id, string requesterEmail, string requesterPassword)
        {
            Role requesterRole = await CheckAuthorization (requesterEmail, requesterPassword);

            if (requesterRole.Name.Equals("student", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new UnauthorizedOperationException("You do not have required access for this operation");
            }

            var user = await this.repository.GetById(id)
                .Include(u => u.Role)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                return this.userMapper.ConvertToDto(user);
            }
            else
            {
                throw new EntityNotFoundException($"There is no user with id: {id}");
            }

        }

        public async Task<User> GetByEmail(string email)
        {

            var user = await this.repository.GetByEmail(email).FirstOrDefaultAsync();

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new EntityNotFoundException($"There is no user with email: {email}");
            }
        }

        //public int GetRoleId(string roleName)
        //{
        //    Role role = this.repository.GetRoles().Where(r => r.Name.ToLower() == roleName.ToLower()).FirstOrDefault();

        //    if (role == null)
        //    {
        //        throw new EntityNotFoundException($"The Api supports the following roles: {string.Join(",", this.repository.GetRoles().Select(r => r.Name).ToList())}");
        //    }

        //    return role.Id;
        //}

        public async Task<List<User>> Get(UserQueryParameters filterParameters)
        {
            if (filterParameters.HasQueryParameters)
            {
                return await this.repository.GetAll().ToListAsync();
            }
            else
            {
                throw new NotImplementedException();

            }

        }

        public async Task<User> Create(UserCreateDto userDto, string imageUrl)
        {
            var user = this.userMapper.ConvertToModel(userDto);
            var userExists = await this.repository.GetAll().AnyAsync(u => u.Email == user.Email);

            if (userExists)
            {
                throw new Exceptions.DuplicateEntityException("User with this email already exists");
            }

            if (imageUrl == null | imageUrl == "string")
            {
                imageUrl = defaultImageUrl;
            }

            return await this.repository.Create(user, imageUrl);

        }


        public async Task<User> Update(int id, UserUpdateDto userUpdateDto, string requesterEmail, string requesterPassword)
        {
            var userToBeUpdated = await this.GetById(id);

            if (userToBeUpdated.Email != requesterEmail | userToBeUpdated.Password != requesterPassword)
            {
                throw new UnauthorizedOperationException("You do not have required access for this operation");
            }

            if (userToBeUpdated.Email == userUpdateDto.Email)
            {
                throw new Exceptions.DuplicateEntityException("User with this email already exists");
            }

            return this.repository.Update(id, this.userMapper.ConvertToModel(userUpdateDto), userUpdateDto.ImageUrl);
            
        }

        public async Task<int> Delete(int id, string requesterEmail, string requesterPassword)
        {
            var userToDelete = await this.GetById(id);

            Role requesterRole = await CheckAuthorization(requesterEmail, requesterPassword);

            if (!requesterRole.Name.Equals("teacher", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new UnauthorizedOperationException("You do not have required access for this operation");
            }
            return await this.repository.Delete(userToDelete);
        }

        public async Task<Role> CheckAuthorization(string requesterEmail, string requesterPassword)
        {

            var requester = await this.repository.GetAll().Where(u => u.Email == requesterEmail & u.Password == requesterPassword).FirstOrDefaultAsync();           

            return requester.Role;
        }
    }
}

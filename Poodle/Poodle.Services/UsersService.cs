﻿using Poodle.Services.Exceptions;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Poodle.Services.Dtos;
using Poodle.Services.Mappers;
using Poodle.Services.Constants;
using Poodle.Services.Helpers;

namespace Poodle.Services.Services
{
    public class UsersService : IUsersService
    {
        
        private readonly IUsersRepository repository;
        private readonly UserMapper userMapper;       

        public UsersService(IUsersRepository repository, UserMapper userMapper)
        {
            this.repository = repository;
            this.userMapper = userMapper;
        }

       
        public async Task<List<User>> GetAll()
        {
            return await this.repository.GetAll().Where(user => user.IsDeleted == false)
             .Include(u => u.Role)
             .Include(u => u.Image)
             .Include(u => u.Courses)
             .ToListAsync();
        }
           
        public async Task<User> GetById(int id)
        {
            var user = (await this.GetAll()).Where(user => user.Id == id).FirstOrDefault();
            return UserHelper.CheckIfUserExists(user);
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = (await this.GetAll()).Where(user => user.Email == email).FirstOrDefault();
            return UserHelper.CheckIfUserExists(user);
        }

        public async Task<List<UserResponseDto>> GetAll(User requester)
        {            
            AuthorizationHelper.ValidateAccess(requester);
            var users = await this.GetAll();
            var userResponseDtos = users.Select(u => userMapper.ConvertToDto(u)).ToList();
            return userResponseDtos;
        }

        public async Task<UserResponseDto> GetById(int id, User requester)
        {            
            AuthorizationHelper.ValidateAccess(requester);
            var user = await this.GetById(id);
            return this.userMapper.ConvertToDto(user); 
        }
             

        public async Task<User> Create(UserCreateDto userDto, string imageUrl)
        {
            var user = this.userMapper.ConvertToModel(userDto);
            var userExists = await this.repository.GetAll().AnyAsync(u => u.Email == user.Email);

            if (userExists)
            {
                throw new DuplicateEntityException(ConstantsContainer.USER_EXISTS);
            }

            if (imageUrl == null)
            {
                imageUrl = ConstantsContainer.DEFAULT_IMAGEURL;
            }

            return await this.repository.Create(user, imageUrl);

        }


        public async Task<User> UpdateApi(int id, UserUpdateDto userUpdateDto, User requester)
        {
            var userToBeUpdated = await this.GetById(id);
            var userEmailExists = await this.repository.GetAll().AnyAsync(u => u.Email == userUpdateDto.Email);

            if (userToBeUpdated.Email != requester.Email | userToBeUpdated.Password != requester.Password)
            {
                throw new UnauthorizedOperationException(ConstantsContainer.RESTRICTED_ACCESS);
            }

            if (userEmailExists && userToBeUpdated.Email != userUpdateDto.Email)
            {
                throw new DuplicateEntityException(ConstantsContainer.USER_EXISTS);
            }

            return await this.repository.Update(id, this.userMapper.ConvertToModel(userUpdateDto), userUpdateDto.ImageUrl);            
        }

        public async Task<User> UpdateWeb(int id, UserUpdateDto userUpdateDto)
        {
            var user = await this.GetById(id);
            var userExists = await this.repository.GetAll().AnyAsync(u => u.Email == userUpdateDto.Email);

            if (userExists && user.Email != userUpdateDto.Email)
            {
                throw new DuplicateEntityException(ConstantsContainer.USER_EXISTS);
            }

            return await this.repository.Update(id, this.userMapper.ConvertToModel(userUpdateDto), userUpdateDto.ImageUrl);
        }  
         
        public async Task<int> Delete(int id, User requester)
        {
            var userToDelete = await this.GetById(id);       
            AuthorizationHelper.ValidateAccess(requester);
            return await this.repository.Delete(userToDelete);
        }
    }
}

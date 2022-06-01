using Poodle.Services.Exceptions;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Poodle.Services.Services
{
    public class UsersService : IUsersService
    {
        public static string defaultImageUrl = "/Images/DefaultImage.jpg";
        private readonly IUsersRepository repository;

        public UsersService(IUsersRepository repository)
        {
            this.repository = repository;
        }

        public List<User> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        public User GetById(int id)
        {
            var user = this.repository.GetById(id).FirstOrDefault();

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new EntityNotFoundException($"There is no user with id: {id}");
            }
        }

        public List<User> GetAll(string requesterEmail, string requesterPassword)
        {
            Role requesterRole = CheckAuthorization(requesterEmail, requesterPassword);

            if (requesterRole.Name.Equals("student", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new UnauthorizedOperationException("You do not have required access for this operation");
            }

            return this.repository.GetAll().ToList();
        }

        public User GetById(int id, string requesterEmail, string requesterPassword)
        {
            Role requesterRole = CheckAuthorization(requesterEmail, requesterPassword);

            if (requesterRole.Name.Equals("student", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new UnauthorizedOperationException("You do not have required access for this operation");
            }
            var user = this.repository.GetById(id).FirstOrDefault();

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new EntityNotFoundException($"There is no user with id: {id}");
            }

        }

        public User GetByEmail(string email)
        {

            var user = this.repository.GetByEmail(email).FirstOrDefault();

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

        public List<User> Get(UserQueryParameters filterParameters)
        {
            if (filterParameters.HasQueryParameters)
            {
                return this.repository.GetAll().ToList();
            }
            else
            {
                throw new NotImplementedException();

            }

        }

        public User Create(User user, string imageUrl)
        {
            var userExists = this.repository.GetAll().Any(u => u.Email == user.Email);

            if (userExists)
            {
                throw new Exceptions.DuplicateEntityException("User with this email already exists");
            }

            if (imageUrl == null | imageUrl == "string")
            {
                imageUrl = defaultImageUrl;
            }

            return this.repository.Create(user, imageUrl);

        }


        public User Update(int id, string firstname, string lastname, string password, string email, string imageUrl, string requesterEmail, string requesterPassword)
        {
            var userToBeUpdated = this.GetById(id);

            if (userToBeUpdated.Email != requesterEmail | userToBeUpdated.Password != requesterPassword)
            {
                throw new UnauthorizedOperationException("You do not have required access for this operation");
            }

            if (userToBeUpdated.Email == email)
            {
                throw new Exceptions.DuplicateEntityException("User with this email already exists");
            }

            return this.repository.Update(id, firstname, lastname, password, email, imageUrl);
            
        }

        public void Delete(int id, string requesterEmail, string requesterPassword)
        {
            var userToDelete = this.GetById(id);

            Role requesterRole = CheckAuthorization(requesterEmail, requesterPassword);

            if (!requesterRole.Name.Equals("teacher", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new UnauthorizedOperationException("You do not have required access for this operation");
            }
            this.repository.Delete(userToDelete);
        }

        public Role CheckAuthorization(string requesterEmail, string requesterPassword)
        {

            var requester = this.repository.GetAll().Where(u => u.Email == requesterEmail & u.Password == requesterPassword).FirstOrDefault();           

            return requester.Role;
        }
    }
}

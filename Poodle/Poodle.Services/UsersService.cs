using Poodle.API.Exceptions;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.API.Services
{
	public class UsersService : IUsersService
	{
		private static string defaultImageUrl = "/Images/DefaultImage.jpg";
		private readonly IUsersRepository repository;

		public UsersService(IUsersRepository repository)
		{
			this.repository = repository;
		}

		public List<User> GetAll(string requesterEmail, string requesterPassword)
		{
			CheckAuthorization(requesterEmail, requesterPassword);
			return this.repository.GetAll().Where(u => u.IsDeleted == false).ToList();
		}

		public User GetById(int id, string requesterEmail, string requesterPassword)
		{
			CheckAuthorization(requesterEmail, requesterPassword);	
			var user = this.repository.GetById(id).FirstOrDefault();

			if (user != null | user.IsDeleted == false)
			{
				return user;
			}
			else
			{
				throw new EntityNotFoundException($"There is no user with id: {id}");
			}
						 
		}

		public User GetByEmail(string email, string requesterEmail, string requesterPassword)
		{
			CheckAuthorization(requesterEmail, requesterPassword);   
			var user = this.repository.GetByEmail(email).FirstOrDefault();

			if (user != null | user.IsDeleted == false)
			{
				return user;
			}
			else
			{
				throw new EntityNotFoundException($"There is no user with email: {email}");
			}
		}

		public List<User> Get(UserQueryParameters filterParameters)
		{
			if (filterParameters.NoQueryParameters)
			{
				return this.repository.GetAll().ToList();
			}
			else
			{
				throw new NotImplementedException();

			}

		}		
		
		public Task<User> Create(User user, int roleId, string imageUrl)
        {
			var userExists = this.repository.GetAll().Any(u => u.Email == user.Email);
			if (userExists)
			{
				throw new Exceptions.DuplicateEntityException("User with this email already registered");
			}

            if (imageUrl == null)
            {
				imageUrl = defaultImageUrl;
            }
			
			return this.repository.Create(user, roleId, imageUrl);

		}
		public User Update(int id, User user)
        {
			throw new NotImplementedException();
		}
		public User Update(int id, User user, string imageUrl)
        {
			throw new NotImplementedException();
		}
		public void Delete(int id, string requesterEmail, string requesterPassword)
        {
			var userToDelete = this.GetById(id, requesterEmail, requesterPassword);
			this.repository.Delete(userToDelete);
		}

		public void CheckAuthorization(string requesterEmail, string requesterPassword)
        {
		
			var requester = this.repository.GetAll().Where(u => u.Email == requesterEmail & u.Password == requesterPassword).FirstOrDefault();

            if (requester == null | requester.IsDeleted == true)
            {
				throw new EntityNotFoundException($"Invalid credentials");
			}
						

			if (requester.Role.Name.Equals("student", StringComparison.CurrentCultureIgnoreCase))
			{
				throw new UnauthorizedOperationException("You do not have required access for this operation");
			}
            
		}
	}
}

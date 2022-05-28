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

		public List<User> Get(string requesterEmail, string requesterPassword)
		{
			CheckAuthorization(requesterEmail, requesterPassword);
			return this.repository.Get().ToList();
		}

		public User Get(int id, string requesterEmail, string requesterPassword)
		{
			CheckAuthorization(requesterEmail, requesterPassword);	
			var user = this.repository.Get(id).FirstOrDefault();

			if (user != null)
			{
				return user;
			}
			else
			{
				throw new EntityNotFoundException($"There is no user with id: {id}");
			}
						 
		}

		public User Get(string email, string requesterEmail, string requesterPassword)
		{
			CheckAuthorization(requesterEmail, requesterPassword);   
			var user = this.repository.Get(email).FirstOrDefault();

			if (user != null)
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
				return this.repository.Get().ToList();
			}
			else
			{
				throw new NotImplementedException();

			}

		}

		public Role GetRole(string email, string password)
        {
			return this.repository.GetAuthorization(email, password).FirstOrDefault().Role;
        }
		
		public Task<User> Create(User user, int roleId, string imageUrl)
        {
			var userExists = this.repository.Get().Any(u => u.Email == user.Email);
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
		public User Delete(int id, bool isDeleted, string requesterEmail, string requesterPassword)
        {
			throw new NotImplementedException();
		}

		private void CheckAuthorization(string requesterEmail, string requesterPassword)
        {
			Role requesterRole = this.GetRole(requesterEmail, requesterPassword);

			if (requesterRole.Name.Equals("student", StringComparison.CurrentCultureIgnoreCase))
			{
				throw new UnauthorizedOperationException("You do not have required access for this operation");
			}
            
		}
	}
}

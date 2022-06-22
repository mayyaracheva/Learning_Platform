using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories;
using Poodle.Services.Constants;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using Poodle.Services.Services;
using System.Threading.Tasks;

namespace Poodle.Tests.SericesTests.Users
{
	[TestClass]
	public class Get_Should : BaseTest
	{
		[TestMethod]
		public async Task Return_AllUsers()
		{
			//Arrange
			var expectedCount = ConstantsContainer.USERS_COUNT;
			//Act
			var context = new ApplicationContext(base.options);
			var repository = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repository, mapper);
			var users = await sut.GetAll();

			//Assert
			Assert.AreEqual(expectedCount, users.Count);
		}

		[TestMethod]
		public async Task Return_AllUsers_AsDTO()
		{
			//Arrange
			var expectedCount = ConstantsContainer.USERS_COUNT;
			var requester = new User
			{
				Id = 1,
				Password = "adminADMIN123?",
				FirstName = "Ragnar",
				LastName = "Lodbrock",
				Email = "Ragnar.Lodbrock@abv.com",
				RoleId = 1,
				ImageId = 1,
			};
			//Act
			var context = new ApplicationContext(base.options);
			var repository = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repository, mapper);
			var users = await sut.GetAll(requester);

			//Assert
			Assert.AreEqual(expectedCount, users.Count);
		}

		[TestMethod]

		public void ThrowsException_If_Requeter_Isnt_Teacher()
		{
			//Arrange 
			var requester = new User
			{
				Id = 3,
				Password = "jondav123*",
				FirstName = "Jonathan",
				LastName = "Davis",
				Email = "Jonathan.Davis@gmail.com",
				RoleId = 2,
				ImageId = 3,
			};
			//Act
			var context = new ApplicationContext(base.options);
			var repo = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repo, mapper);

			//Assert
			Assert.ThrowsExceptionAsync<UnauthorizedOperationException>(() => sut.GetAll(requester));
		}

	}
}

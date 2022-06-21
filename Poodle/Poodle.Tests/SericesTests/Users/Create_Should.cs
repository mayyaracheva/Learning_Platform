using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poodle.Data;
using Poodle.Repositories;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using Poodle.Services.Services;
using System.Threading.Tasks;

namespace Poodle.Tests.SericesTests.Users
{
	[TestClass]
	public class Create_Should : BaseTest
	{
		[TestMethod]
		public async Task Return_TheCreatedUser()
		{
			//Arrange
			var newUser = new UserCreateDto()
			{
				Password = "testUser123?",
				FirstName = "JohnTest",
				LastName = "JacksonTest",
				Email = "john.test@gmail.com",
			};
			//Act
			var context = new ApplicationContext(base.options);
			var repository = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repository, mapper);
			var actualUser = await sut.Create(newUser, null);
			//Assert
			Assert.AreEqual(11, actualUser.Id);
		}

		[TestMethod]
		public void Throw_Exception_If_UserExists()
		{
			//Arrange
			var userDto = new UserCreateDto()
			{
				Password = "johnJOHN123!",
				FirstName = "Jack",
				LastName = "Richmond",
				Email = "Jack.Richmond@yahoo.com",
			};
			//Act
			var context = new ApplicationContext(base.options);
			var repository = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repository, mapper);
			//Assert
			Assert.ThrowsExceptionAsync<DuplicateEntityException>(() => sut.Create(userDto, null));
		}
	}
}

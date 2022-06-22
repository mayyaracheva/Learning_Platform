using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories;
using Poodle.Services.Constants;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using Poodle.Services.Services;
using System.Threading.Tasks;

namespace Poodle.Tests.SericesTests.Users
{
	[TestClass]
	public class Get_User_ByID_Should : BaseTest
	{
		[TestMethod]

		public async Task Return_UserWith_CorrectID()
		{
			//Arrange
			var expectedUser = new User()
			{
				Id = 10,
				Password = "marrob123!",
				FirstName = "Mario",
				LastName = "Caruso",
				Email = "Mario.Caruso@gmail.com",
				RoleId = 2,
				ImageId = 10,
			};

			//Act
			var context = new ApplicationContext(base.options);
			var repository = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repository, mapper);
			var actualUser = await sut.GetById(10);

			//Assert
			Assert.AreEqual(expectedUser.Id, actualUser.Id);
			Assert.AreEqual(expectedUser.FirstName, actualUser.FirstName);
			Assert.AreEqual(expectedUser.Password, actualUser.Password);
		}

		[TestMethod]

		public void ThrowsException_If_ID_Is_InCorrect()
		{
			//Arrange //Act
			var context = new ApplicationContext(base.options);
			var repo = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repo, mapper);

			//Assert
			Assert.ThrowsExceptionAsync<EntityNotFoundException>(() => sut.GetById(0));
		}

		[TestMethod]
		public async Task Return_UserDTO_With_CorrectID()
		{
			//Arrange
			var id = 10;
			var expectedUser = new UserResponseDto()
			{
				FirstName = "Mario",
				LastName = "Caruso",
				Email = "Mario.Caruso@gmail.com",
				Role = ConstantsContainer.STUDENT,
			};
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
			var actualUser = await sut.GetById(id, requester);

			//Assert
			Assert.AreEqual(expectedUser.Email, actualUser.Email);
			Assert.AreEqual(expectedUser.FirstName, actualUser.FirstName);
			Assert.AreEqual(expectedUser.Role, actualUser.Role);
		}

		[TestMethod]
		public void ThrowsException_If_DTO_ID_Is_Incorrect()
		{
			//Arrange 
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
			var repo = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repo, mapper);

			//Assert
			Assert.ThrowsExceptionAsync<EntityNotFoundException>(() => sut.GetById(0, requester));
		}

		[TestMethod]
		public void ThrowsException_If_Requester_Is_NotAuthorized()
		{
			//Arrange 
			var requester = new User
			{
				Id = 10,
				Password = "marrob123!",
				FirstName = "Mario",
				LastName = "Caruso",
				Email = "Mario.Caruso@gmail.com",
				RoleId = 2,
				ImageId = 10,
			};
			//Act
			var context = new ApplicationContext(base.options);
			var repo = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repo, mapper);

			//Assert
			Assert.ThrowsExceptionAsync<EntityNotFoundException>(() => sut.GetById(10, requester));
		}
	}
}

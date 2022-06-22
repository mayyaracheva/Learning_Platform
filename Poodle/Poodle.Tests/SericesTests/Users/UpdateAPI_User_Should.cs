using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using Poodle.Services.Services;
using System.Threading.Tasks;

namespace Poodle.Tests.SericesTests.Users
{
	[TestClass]
	public class UpdateAPI_User_Should : BaseTest
	{
		//UpdateAPI tests

		[TestMethod]
		public async Task Return_TheUpdatedUser()
		{
			//Arrange
			int id = 10;
			var userUpdateDto = new UserUpdateDto()
			{
				Password = "marrob123!",
				FirstName = "Ignatio",
				LastName = "Caruso",
				Email = "Mario.Caruso@gmail.com",
				ImageUrl = "string"
			};
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
			var repository = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repository, mapper);
			var updatedUser = await sut.UpdateApi(id, userUpdateDto, requester);
			//Assert
			Assert.AreEqual(userUpdateDto.FirstName, updatedUser.FirstName);
		}

		[TestMethod]

		public void ThrowsException_If_Requester_IsUnauthorized()
		{
			//Arrange
			int id = 10;
			var userUpdateDto = new UserUpdateDto()
			{
				Password = "marrob123!",
				FirstName = "Ignatio",
				LastName = "Caruso",
				Email = "Mario.Caruso@gmail.com",
				ImageUrl = "string"
			};
			var requester = new User
			{
				Id = 9,
				Password = "hardiR789*",
				FirstName = "Harriet",
				LastName = "Dark",
				Email = "Harriet.Dark@gmail.com",
				RoleId = 2,
				ImageId = 9,
			};
			//Act
			var context = new ApplicationContext(base.options);
			var repository = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repository, mapper);

			//Assert
			Assert.ThrowsExceptionAsync<UnauthorizedOperationException>(() => sut.UpdateApi(id, userUpdateDto, requester));
		}

		[TestMethod]

		public void ThrowsException_If_User_eMail_IsNotUnique()
		{
			//Arrange
			int id = 10;
			var userUpdateDto = new UserUpdateDto()
			{
				Password = "marrob123!",
				FirstName = "Ignatio",
				LastName = "Caruso",
				Email = "Harriet.Dark@gmail.com",
				ImageUrl = "string"
			};
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
			var repository = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repository, mapper);

			//Assert
			Assert.ThrowsExceptionAsync<DuplicateEntityException>(() => sut.UpdateApi(id, userUpdateDto, requester));
		}
	}
}

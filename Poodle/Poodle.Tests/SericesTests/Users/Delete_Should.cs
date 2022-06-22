using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using Poodle.Services.Services;
using System.Threading.Tasks;

namespace Poodle.Tests.SericesTests.Users
{
	[TestClass]
	public class Delete_Should : BaseTest
	{
		[TestMethod]
		public async Task Return_DeletedUserID()
		{
			//Arrange
			var userToDelete = new User
			{
				Id = 10,
				Password = "marrob123!",
				FirstName = "Mario",
				LastName = "Caruso",
				Email = "Mario.Caruso@gmail.com",
				RoleId = 2,
				ImageId = 10,
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
			var repo = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repo, mapper);
			var id = await sut.Delete(10, requester);
			//Assert
			Assert.AreEqual(userToDelete.Id, id);
		}

		[TestMethod]

		public void ThrowsException_If_UserDoesntExist()
		{
			//Arrange //Act
			var context = new ApplicationContext(base.options);
			var repo = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repo, mapper);

			//Assert
			Assert.ThrowsExceptionAsync<EntityNotFoundException>(() => sut.Delete(12, new User()));
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
			Assert.ThrowsExceptionAsync<UnauthorizedOperationException>(() => sut.Delete(10, requester));
		}


	}
}

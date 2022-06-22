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
	public class GetByEmail_Should : BaseTest
	{
		[TestMethod]

		public async Task Return_Correct_User()
		{
			//Arrange
			var expectedUser = new User
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
			var actualUser = await sut.GetByEmail(expectedUser.Email);

			//Assert
			Assert.AreEqual(expectedUser.Id, actualUser.Id);
			Assert.AreEqual(expectedUser.FirstName, actualUser.FirstName);
			Assert.AreEqual(expectedUser.Password, actualUser.Password);
		}

		[TestMethod]

		public void ThrowsException_If_Email_Is_InCorrect()
		{
			//Arrange
			string email = "Jack.Sparrow@gmail.com";
			//Act
			var context = new ApplicationContext(base.options);
			var repo = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repo, mapper);

			//Assert
			Assert.ThrowsExceptionAsync<EntityNotFoundException>(() => sut.GetByEmail(email));
		}
	}
}

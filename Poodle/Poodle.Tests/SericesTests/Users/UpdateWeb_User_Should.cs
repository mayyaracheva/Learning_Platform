using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poodle.Data;
using Poodle.Repositories;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using Poodle.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Tests.SericesTests.Users
{
    [TestClass]
    public class UpdateWeb_User_Should : BaseTest
    {
		//UpdateWeb tests

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
			//Act
			var context = new ApplicationContext(base.options);
			var repository = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repository, mapper);
			var updatedUser = await sut.UpdateWeb(id, userUpdateDto);
			//Assert
			Assert.AreEqual(userUpdateDto.FirstName, updatedUser.FirstName);
		}

        [TestMethod]
		public void ThrowsException_If_User_eMail_IsNotUnique()
		{
			//Arrange
			int id = 10;
			var userUpdateDto = new UserUpdateDto()
			{
				Password = "marrob123!",
				FirstName = "Mario",
				LastName = "Caruso",
				Email = "Harriet.Dark@gmail.com",
				ImageUrl = "string"
			};
			//Act
			var context = new ApplicationContext(base.options);
			var repository = new UsersRepository(context);
			var mapper = new UserMapper();
			var sut = new UsersService(repository, mapper);

			//Assert
			Assert.ThrowsExceptionAsync<DuplicateEntityException>(() => sut.UpdateWeb(id, userUpdateDto));
		}
	}
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using Poodle.Services;
using Poodle.Services.Contracts;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Tests.SericesTests.Courses
{
	[TestClass]
	public class Create_Sould
	{
		[TestMethod]
		public async Task ReturnCorrectBeer_When_ParamsAreValid()
		{
			// Arrange
			var courseDTO = new CourseDTO
			{
				Title = "Implementing and Administering Solutions(CCNA)",
				Description = "The course gives you a broad range of fundamental knowledge for all IT careers. Through a combination of lecture, hands-on labs, and self-study, you will learn how to install, operate, configure, and verify basic IPv4 and IPv6 networks. The course covers configuring network components such as switches, routers, and wireless LAN controllers; managing network devices; and identifying basic security threats. The course also gives you a foundation in network programmability, automation, and software-defined networking.",
				CategoryId = 1,
				PhotoURL = "img/course-1.jpg",
			};
			var expectedCourse = new Course
			{
				Id = 1,
				Title = "Implementing and Administering Solutions(CCNA)",
				Description = "The course gives you a broad range of fundamental knowledge for all IT careers. Through a combination of lecture, hands-on labs, and self-study, you will learn how to install, operate, configure, and verify basic IPv4 and IPv6 networks. The course covers configuring network components such as switches, routers, and wireless LAN controllers; managing network devices; and identifying basic security threats. The course also gives you a foundation in network programmability, automation, and software-defined networking.",
				CategoryId = 1,
				PhotoURL = "img/course-1.jpg",
			};

			var user = new User
			{
				Id = 1,
				Password = "adminADMIN123?",
				FirstName = "Ragnar",
				LastName = "Lodbrock",
				Email = "Ragnar.Lodbrock@abv.com",
				RoleId = 1,
				ImageId = 1,
			};
			var coursesRepositoryMock = new Mock<ICoursesRepository>();
			var mapperMock = new Mock<CourseMapper>();
			var usersRepositoryMock = new Mock<IUsersRepository>();
			var coursesServiceMock = new Mock<ICoursesService>();
			 mapperMock
				.Setup(map => map.Convert(courseDTO))
				.Returns(expectedCourse);

			//await coursesServiceMock
			//	.Setup(repo => repo.(It.IsAny<string>()))
			//	.Throws(new DuplicateEntityException());

			//await coursesRepositoryMock
			//	.Setup(repo => repo.CreateAsync(It.IsAny<Course>()))
			//	.Returns(expectedCourse);

			var sut = new CoursesService(coursesRepositoryMock.Object, 
				mapperMock.Object,
				usersRepositoryMock.Object);

			// Act
			var actualCourse = await sut.CreateAsync(courseDTO, user);

			// Assert
			Assert.AreEqual(expectedCourse.Id, actualCourse.Id);
			Assert.AreEqual(expectedCourse.Title, actualCourse.Title);
			Assert.AreEqual(expectedCourse.Description, actualCourse.Description);
		}
	}
}

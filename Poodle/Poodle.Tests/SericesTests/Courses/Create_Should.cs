using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories;
using Poodle.Services;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;

namespace Poodle.Tests.SericesTests.Courses
{
	[TestClass]
	public class Create_Should : BaseTest
	{
		//[TestMethod]
		//public async Task ReturnCorrectCourse_When_ParamsAreValid()
		//{ }

			[TestMethod]
		public void ThrowsException_When_CourseExists()
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
				Id = 11,
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

			// Act

			var context = new ApplicationContext(base.options);
			var coursesRepository = new CoursesRepository(context);
			var mapper = new CourseMapper();
			var usersRepository = new UsersRepository(context);
			var sut = new CoursesService(coursesRepository,
										mapper, 
										usersRepository);

            // Assert
            Assert.ThrowsExceptionAsync<DuplicateEntityException>(() => sut.CreateAsync(courseDTO, user));
		}
	}
}

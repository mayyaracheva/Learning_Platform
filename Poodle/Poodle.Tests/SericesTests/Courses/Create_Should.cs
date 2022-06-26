using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories;
using Poodle.Repositories.Contracts;
using Poodle.Services;
using Poodle.Services.Dtos;
using Poodle.Services.Exceptions;
using Poodle.Services.Mappers;
using System.Threading.Tasks;

namespace Poodle.Tests.SericesTests.Courses
{
	[TestClass]
	public class Create_Should : BaseTest
	{
		[TestMethod]
		public async Task Return_TheCreatedCourse()
		{
			//Arrange
			int id = 11;
			var courseDTO = new CourseDTO
            {
                Title = "Create Azure App Service web apps",
                Description = "Learn how Azure App Service functions and how to create and update an app. Explore App Service authentication and authorization, configuring app settings, scale apps, and how to use deployment slots.",
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
			//Act
			var context = new ApplicationContext(base.options);
			var coursesRepo = new CoursesRepository(context);
			var usersRepoMock = new Mock<IUsersRepository>();
			Mock<CourseMapper> coursesMapper = new();

			var sut = new CoursesService(coursesRepo, coursesMapper.Object, usersRepoMock.Object);
			var actualCourse = await sut.CreateAsync(courseDTO, user);

			//Assert
			Assert.AreEqual(id, actualCourse.Id);
			Assert.AreEqual(courseDTO.Title, actualCourse.Title);
			Assert.AreEqual(courseDTO.Description, actualCourse.Description);
		}
		//private Mock<IUsersRepository> usersRepo;
		//private ICoursesRepository coursesRepo;
		//private ICoursesService coursesService;
		//private Mock<CourseMapper> courseMapper = new();

		//private ApplicationContext context;
		//[TestInitialize]
		//public void Init()
		//{
		//	context = Utils.GetInMemoryContext();
		//	coursesRepo = new CoursesRepository(context);
		//	usersRepo = new Mock<IUsersRepository>();
		//	coursesService = new CoursesService(coursesRepo, courseMapper.Object, usersRepo.Object);
		//	Utils.SeedDatabase(context);
		//}

		//[TestCleanup]
		//public void CleanUp()
		//{
		//	context.Database.EnsureDeleted();
		//}
		//	[TestMethod]
		//public void ThrowsException_When_CourseExists()
		//{
		//	// Arrange
		//	var courseDTO = new CourseDTO
		//	{
		//		Title = "Implementing and Administering Solutions(CCNA)",
		//		Description = "The course gives you a broad range of fundamental knowledge for all IT careers. Through a combination of lecture, hands-on labs, and self-study, you will learn how to install, operate, configure, and verify basic IPv4 and IPv6 networks. The course covers configuring network components such as switches, routers, and wireless LAN controllers; managing network devices; and identifying basic security threats. The course also gives you a foundation in network programmability, automation, and software-defined networking.",
		//		CategoryId = 1,
		//		PhotoURL = "img/course-1.jpg",
		//	};
		//	var expectedCourse = new Course
		//	{
		//		Id = 11,
		//		Title = "Implementing and Administering Solutions(CCNA)",
		//		Description = "The course gives you a broad range of fundamental knowledge for all IT careers. Through a combination of lecture, hands-on labs, and self-study, you will learn how to install, operate, configure, and verify basic IPv4 and IPv6 networks. The course covers configuring network components such as switches, routers, and wireless LAN controllers; managing network devices; and identifying basic security threats. The course also gives you a foundation in network programmability, automation, and software-defined networking.",
		//		CategoryId = 1,
		//		PhotoURL = "img/course-1.jpg",
		//	};

		//	var user = new User
		//	{
		//		Id = 1,
		//		Password = "adminADMIN123?",
		//		FirstName = "Ragnar",
		//		LastName = "Lodbrock",
		//		Email = "Ragnar.Lodbrock@abv.com",
		//		RoleId = 1,
		//		ImageId = 1,
		//	};

		//	// Act

		//	var context = new ApplicationContext(base.options);
		//	var coursesRepository = new CoursesRepository(context);
		//	var mapper = new CourseMapper();
		//	var usersRepository = new UsersRepository(context);
		//	var sut = new CoursesService(coursesRepository,
		//								mapper, 
		//								usersRepository);

		//          // Assert
		//          Assert.ThrowsExceptionAsync<DuplicateEntityException>(() => sut.CreateAsync(courseDTO, user));
		//}

		[TestMethod]
		[ExpectedException(typeof(DuplicateEntityException))]
		public async Task ThrowsException_When_CourseExists()
		{
			// Arrange
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
			var context = new ApplicationContext(base.options);
			var coursesRepo = new CoursesRepository(context);
			var usersRepoMock = new Mock<IUsersRepository>();
            Mock<CourseMapper> coursesMapper = new();

            var sut = new CoursesService(coursesRepo, coursesMapper.Object, usersRepoMock.Object);
            // Act & Assert
            await sut.CreateAsync(new CourseDTO { Title = "Implementing and Administering Solutions(CCNA)" }, user);
		}

		[TestMethod]

		public async Task ThrowsException_If_Requester_IsUnauthorized()
		{
			//Arrange
			var courseDTO = new CourseDTO
			{
				Title = "Create Azure App Service web apps",
				Description = "Learn how Azure App Service functions and how to create and update an app. Explore App Service authentication and authorization, configuring app settings, scale apps, and how to use deployment slots.",
				CategoryId = 1,
				PhotoURL = "img/course-1.jpg",
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
			var coursesRepo = new CoursesRepository(context);
			var usersRepoMock = new Mock<IUsersRepository>();
			Mock<CourseMapper> coursesMapper = new();

			var sut = new CoursesService(coursesRepo, coursesMapper.Object, usersRepoMock.Object);

			//Assert
			await Assert.ThrowsExceptionAsync<UnauthorizedOperationException>(() => sut.CreateAsync(courseDTO, requester));
		}
	}
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poodle.Data;
using Poodle.Repositories;
using Poodle.Services;
using Poodle.Services.Constants;
using System.Linq;

namespace Poodle.Tests.SericesTests.Home
{
    [TestClass]	
    public class Get_PublicCourses_Async_Should : BaseTest
    {
		[TestMethod]
		public void Return_AllUsers()
		{
			//Arrange
			var expectedCount = ConstantsContainer.PUBLIC_COURSES_COUNT;
			//Act
			var context = new ApplicationContext(base.options);
			var repo = new CoursesRepository(context);
			var sut = new HomeService(repo);
			var courses = sut.GetPublicCoursrses();
			//Assert
			Assert.AreEqual(expectedCount, courses.Count());
		}
	}
}

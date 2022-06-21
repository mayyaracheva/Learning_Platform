using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poodle.Data;

namespace Poodle.Tests
{
	[TestClass]
	public abstract class BaseTest
	{
		protected DbContextOptions<ApplicationContext> options;

		[TestInitialize]
		public void Initialialize()
		{
			string dataBaseName = "TestDB";
			this.options = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase(dataBaseName).Options;
			var context = new ApplicationContext(this.options);
			context.Users.AddRange(ModelBuilderExtension.GetUsers());
			context.Courses.AddRange(ModelBuilderExtension.GetCourses());
			context.Sections.AddRange(ModelBuilderExtension.GetSections());
			context.Roles.AddRange(ModelBuilderExtension.GetRoles());
			context.Categories.AddRange(ModelBuilderExtension.GetCategories());
			context.Subscriptions.AddRange(ModelBuilderExtension.GetSubscriptions());
			context.Images.AddRange(ModelBuilderExtension.GetImages());
			context.SaveChanges();
		}

		[TestCleanup]
		public void Cleanup()
		{
			var context = new ApplicationContext(this.options);
			context.Database.EnsureDeleted();
		}
	}
}


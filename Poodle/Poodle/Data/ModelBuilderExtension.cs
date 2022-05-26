using Microsoft.EntityFrameworkCore;
using Poodle.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Data
{
    public static class ModelBuilderExtension
    {
		private static string defaultImageData = "/Images/DefaultImage.jpg";
		public static void Seed(this ModelBuilder modelBuilder)
		{
			
			List<Image> profileImages = GetImages();
			modelBuilder.Entity<Image>().HasData(profileImages);

			//List<User> users = GetUsers();
			//modelBuilder.Entity<User>().HasData(users);

			//List<Course> courses = GetCourses();
			//modelBuilder.Entity<Course>().HasData(courses);

			//List<Section> sections = GetSections();
			//modelBuilder.Entity<Section>().HasData(sections);

			//List<Role> roles = GetRoles();
			//modelBuilder.Entity<Role>().HasData(roles);

			//List<Category> categories = GetCategories();
			//modelBuilder.Entity<Category>().HasData(categories);

		}

		public static List<Image> GetImages()
		{
			var profileimages = new List<Image>();
			profileimages.Add(new Image
			{
				Id = 1,
				ImageUrl = defaultImageData,
				UserId = 1
			});
			profileimages.Add(new Image
			{
				Id = 2,
				ImageUrl = defaultImageData,
				UserId = 3
			});
			profileimages.Add(new Image
			{
				Id = 3,
				ImageUrl = defaultImageData,
				UserId = 2
			});
			profileimages.Add(new Image
			{
				Id = 4,
				ImageUrl = defaultImageData,
				UserId = 4
			});
			profileimages.Add(new Image
			{
				Id = 5,
				ImageUrl = defaultImageData,
				UserId = 5
			});
			return profileimages;
		}

		//public static List<User> GetUsers()
		//{
		//	var users = new List<User>();
		//	users.Add(new User
		//	{
		//		Id = 1,				
		//		Password = "adminADMIN123?",
		//		FirstName = "Ignatio",
		//		LastName = "Italiano",
		//		Email = "Ignatio.Italia@gmail.com",
		//		RoleId = 1,				
		//		ImageId = 1,
		//		CreatedOn = DateTime.UtcNow,
		//		ModifiedOn = DateTime.UtcNow
		//	});
		//	users.Add(new User
		//	{
		//		Id = 2,
		//		UserName = "John",
		//		Password = "johnJOHN123!",
		//		FirstName = "Jack",
		//		LastName = "Daniels",
		//		Email = "Jack.Daniels@yahoo.com",
		//		RoleId = 2,
		//		ImageId = 3,
		//		CreatedOn = DateTime.UtcNow,
		//		ModifiedOn = DateTime.UtcNow
		//	});
		//	users.Add(new User
		//	{
		//		Id = 3,
		//		UserName = "Jimbo",
		//		Password = "jackJack123*",
		//		FirstName = "JimJim",
		//		LastName = "Beam",
		//		Email = "Jim-BeamUSA@gmail.com",
		//		RoleId = 2,
		//		ImageId = 2,
		//		CreatedOn = DateTime.UtcNow,
		//		ModifiedOn = DateTime.UtcNow
		//	});
		//	users.Add(new User
		//	{
		//		Id = 4,
		//		UserName = "Johnnn",
		//		Password = "jackJack123*",
		//		FirstName = "Johnnie",
		//		LastName = "Walker",
		//		Email = "Johnnie.Walker@gmail.com",
		//		RoleId = 2,
		//		ImageId = 4,
		//		CreatedOn = DateTime.UtcNow,
		//		ModifiedOn = DateTime.UtcNow
		//	});
		//	users.Add(new User
		//	{
		//		Id = 5,
		//		UserName = "Jamesonnn",
		//		Password = "jamesonN123*",
		//		FirstName = "Jameson",
		//		LastName = "BlackBarel",
		//		Email = "Jameson.BlackBarel@gmail.com",
		//		RoleId = 2,
		//		ImageId = 5,
		//		CreatedOn = DateTime.UtcNow,
		//		ModifiedOn = DateTime.UtcNow
		//	});
		//	return users;
		//}


	}
}

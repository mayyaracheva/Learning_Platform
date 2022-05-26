using Microsoft.EntityFrameworkCore;
using Poodle.Database.EntityModels;
using System;
using System.Collections.Generic;

namespace Poodle.Database.Data
{
    public static class ModelBuilderExtension
    {
		private static string defaultImageData = "/Images/DefaultImage.jpg";
		public static void Seed(this ModelBuilder modelBuilder)
		{
			
			List<Image> profileImages = GetImages();
			modelBuilder.Entity<Image>().HasData(profileImages);

			List<User> users = GetUsers();
			modelBuilder.Entity<User>().HasData(users);

			List<Course> courses = GetCourses();
			modelBuilder.Entity<Course>().HasData(courses);

			List<Section> sections = GetSections();
			modelBuilder.Entity<Section>().HasData(sections);

			List<Role> roles = GetRoles();
			modelBuilder.Entity<Role>().HasData(roles);

			List<Category> categories = GetCategories();
			modelBuilder.Entity<Category>().HasData(categories);

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
				UserId = 2
			});
			profileimages.Add(new Image
			{
				Id = 3,
				ImageUrl = defaultImageData,
				UserId = 3
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
			profileimages.Add(new Image
			{
				Id = 6,
				ImageUrl = defaultImageData,
				UserId = 6
			});
			profileimages.Add(new Image
			{
				Id = 7,
				ImageUrl = defaultImageData,
				UserId = 7
			});
			profileimages.Add(new Image
			{
				Id = 8,
				ImageUrl = defaultImageData,
				UserId = 9
			});
			profileimages.Add(new Image
			{
				Id = 10,
				ImageUrl = defaultImageData,
				UserId = 10
			});
			profileimages.Add(new Image
			{
				Id = 11,
				ImageUrl = defaultImageData,
				UserId = 11
			});

			return profileimages;
		}

		public static List<User> GetUsers()
		{
			var users = new List<User>();
			users.Add(new User
			{
				Id = 1,
				Password = "adminADMIN123?",
				FirstName = "Ragnar",
				LastName = "Lodbrock",
				Email = "John.Hanes@gmail.com",
				RoleId = 1,
				ImageId = 1,
				//CreatedOn = DateTime.UtcNow,
				//ModifiedOn = DateTime.UtcNow
			});
			users.Add(new User
			{
				Id = 2,
				Password = "johnJOHN123!",
				FirstName = "Jack",
				LastName = "Richmond",
				Email = "Jack.Richmond@yahoo.com",
				RoleId = 2,
				ImageId = 2,
				//CreatedOn = DateTime.UtcNow,
				//ModifiedOn = DateTime.UtcNow
			});
			users.Add(new User
			{
				Id = 3,
				Password = "jondav123*",
				FirstName = "Jonathan",
				LastName = "Davis",
				Email = "Jonathan.Davis@gmail.com",
				RoleId = 2,
				ImageId = 2,
				//CreatedOn = DateTime.UtcNow,
				//ModifiedOn = DateTime.UtcNow
			});
			users.Add(new User
			{
				Id = 4,
				Password = "ignitalo123*",
				FirstName = "Ignatio",
				LastName = "Italiano",
				Email = "Ignatio.Italiano@gmail.com",
				RoleId = 2,
				ImageId = 4,
				//CreatedOn = DateTime.UtcNow,
				//ModifiedOn = DateTime.UtcNow
			});
			users.Add(new User
			{
				Id = 5,
				Password = "jamesonN123*",
				FirstName = "Reginald",
				LastName = "Hargreeves",
				Email = "Reginald.Hargreeves@gmail.com",
				RoleId = 3,
				ImageId = 5,
				//CreatedOn = DateTime.UtcNow,
				//ModifiedOn = DateTime.UtcNow
			});
			users.Add(new User
			{
				Id = 6,
				Password = "johnsonN123*",
				FirstName = "John",
				LastName = "Hanes",
				Email = "John.Hanes@gmail.com",
				RoleId = 3,
				ImageId = 6,
				//CreatedOn = DateTime.UtcNow,
				//ModifiedOn = DateTime.UtcNow
			});
			users.Add(new User
			{
				Id = 7,
				Password = "horspanP123*",
				FirstName = "Horatio",
				LastName = "Spanish",
				Email = "Horatio.Spanish@gmail.com",
				RoleId = 3,
				ImageId = 7,
				//CreatedOn = DateTime.UtcNow,
				//ModifiedOn = DateTime.UtcNow
			});
			users.Add(new User
			{
				Id = 8,
				Password = "hurspenM456!",
				FirstName = "Herbert",
				LastName = "Spencer",
				Email = "Herbert.Spencer@gmail.com",
				RoleId = 3,
				ImageId = 8,
				//CreatedOn = DateTime.UtcNow,
				//ModifiedOn = DateTime.UtcNow
			});
			users.Add(new User
			{
				Id = 9,
				Password = "hardiR789*",
				FirstName = "Harriet",
				LastName = "Dark",
				Email = "Harriet.Dark@gmail.com",
				RoleId = 3,
				ImageId = 9,
				//CreatedOn = DateTime.UtcNow,
				//ModifiedOn = DateTime.UtcNow
			});
			users.Add(new User
			{
				Id = 10,
				Password = "marrob123!",
				FirstName = "Mario",
				LastName = "Caruso",
				Email = "Mario.Caruso@gmail.com",
				RoleId = 3,
				ImageId = 10,
				//CreatedOn = DateTime.UtcNow,
				//ModifiedOn = DateTime.UtcNow
			});
			return users;
		}

		public static List<Course> GetCourses()
		{
			throw new NotImplementedException();
		}

		public static List<Section> GetSections()
		{
			throw new NotImplementedException();
		}

		public static List<Role> GetRoles()
		{
			var roles = new List<Role>();
			roles.Add(new Role
			{
				Id = 1,
				Name = "Admin"
			});
			roles.Add(new Role
			{
				Id = 2,
				Name = "Teacher"
			});
			roles.Add(new Role
			{
				Id = 3,
				Name = "Student"
			});
			return roles;
		}
		public static List<Category> GetCategories()
		{
			throw new NotImplementedException();
		}

	}
}

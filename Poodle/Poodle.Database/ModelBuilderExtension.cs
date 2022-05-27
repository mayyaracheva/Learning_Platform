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
			var courses = new List<Course>();

			courses.Add(new Course
			{
				Id = 1,
				Title = "Implementing and Administering Cisco Solutions(CCNA)",
				Description = "The course gives you a broad range of fundamental knowledge for all IT careers. Through a combination of lecture, hands-on labs, and self-study, you will learn how to install, operate, configure, and verify basic IPv4 and IPv6 networks. The course covers configuring network components such as switches, routers, and wireless LAN controllers; managing network devices; and identifying basic security threats. The course also gives you a foundation in network programmability, automation, and software-defined networking.",
				CategoryId = 1
			});
			courses.Add(new Course
			{
				Id = 2,
				Title = "Developing Applications Using Cisco Core Platforms and APIs (DEVCOR)",
				Description = "The course helps you prepare for Cisco DevNet Professional certification and for professional-level network automation engineer roles. You will learn how to implement network applications using Cisco® platforms as a base, from initial software design to diverse system integration, as well as testing and deployment automation. The course gives you hands-on experience solving real world problems using Cisco Application Programming Interfaces (APIs) and modern development tools.",
				CategoryId = 1
			});
			courses.Add(new Course
			{
				Id = 3,
				Title = "Configuring Cisco Unified Computing System (DCCUCS)",
				Description = "The course shows you how to deploy, secure, operate, and maintain Cisco Unified Computing System™ (Cisco UCS®) B-series blade servers, Cisco UCS C-Series, and S-Series rack servers for use in data centers. You will learn how to implement management and orchestration software for Cisco UCS. You will gain hands-on practice: configuring key features of Cisco UCS, Cisco UCS Director, and Cisco UCS Manager; implementing UCS management software including Cisco UCS Manager and Cisco Intersight™; and more.",
				CategoryId = 1
			});
			courses.Add(new Course
			{
				Id = 4,
				Title = "Implementing Cisco Application Centric Infrastructure (DCACI)",
				Description = "The course shows you how to deploy and manage the Cisco® Nexus® 9000 Series Switches in Cisco Application Centric Infrastructure (Cisco ACI®) mode. You will learn how to configure and manage Cisco Nexus 9000 Series Switches in ACI mode, how to connect the Cisco ACI fabric to external networks and services, and the fundamentals of Virtual Machine Manager (VMM) integration. You will gain hands-on practice implementing key capabilities such as fabric discovery, policies, connectivity, VMM integration, and more.",
				CategoryId = 2
			});
			courses.Add(new Course
			{
				Id = 5,
				Title = "Cisco Nexus 9000 Switches in NX-OS Mode",
				Description = "The course shows you how to implement, manage, and troubleshoot Cisco Nexus® 9000 Series Switches in Cisco® NX-OS mode. Through expert instruction and extensive hands-on learning, you will learn how to deploy capabilities including Virtual Extensible LAN (VXLAN), Multiprotocol Label Switching (MPLS), high availability features, Intelligent Traffic Director, troubleshooting tools and techniques, NX-OS programmability features, and open interface technologies.",
				CategoryId = 2
			});


			return courses;	
		}

		
		public static List<Section> GetSections()
		{
			var sections = new List<Section>();

			sections.Add(new Section
			{
				Id = 1,
				Title = "Exploring the Functions of Networking",				
				CourseId = 1
			});
			sections.Add(new Section
			{
				Id = 2,
				Title = "Introducing the Host-to-Host Communications Model",
				CourseId = 1
			});
			sections.Add(new Section
			{
				Id = 3,
				Title = "Operating Cisco IOS Software",
				CourseId = 1
			});
			sections.Add(new Section
			{
				Id = 4,
				Title = "Designing for Maintainability",
				CourseId = 2
			});
			sections.Add(new Section
			{
				Id = 5,
				Title = "Designing for Serviceability",
				CourseId = 2
			});
			sections.Add(new Section
			{
				Id = 6,
				Title = "Describing Advanced REST API Integration",
				CourseId = 2
			});
			sections.Add(new Section
			{
				Id = 7,
				Title = "Implementing Cisco UCS Storage Area Network (SAN)",
				CourseId = 3
			});
			sections.Add(new Section
			{
				Id = 8,
				Title = "Implementing External Authentication Providers",
				CourseId = 3
			});
			sections.Add(new Section
			{
				Id = 9,
				Title = "Describing Cisco UCS Policies for Service Profiles",
				CourseId = 3
			});
			sections.Add(new Section
			{
				Id = 10,
				Title = "Ethernet switching products",
				CourseId = 4
			});
			sections.Add(new Section
			{
				Id = 11,
				Title = "Data center architecture",
				CourseId = 4
			});
			sections.Add(new Section
			{
				Id = 12,
				Title = "Understanding of networking protocols, routing, and switching",
				CourseId = 4
			});
			sections.Add(new Section
			{
				Id = 13,
				Title = "Data Center Trends",
				CourseId = 5
			});
			sections.Add(new Section
			{
				Id = 14,
				Title = "Describing Cisco Nexus 9000 Series Hardware",
				CourseId = 5
			});
			sections.Add(new Section
			{
				Id = 15,
				Title = "Cisco Nexus 9000 NX-OS Features",
				CourseId = 5
			});

			return sections;
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
			var categories = new List<Category>();
			categories.Add(new Category
			{
				Id = 1,
				Name = "Public"
			});
			categories.Add(new Category
			{
				Id = 2,
				Name = "Private"
			});
			categories.Add(new Category
			{
				Id = 3,
				Name = "Hidden"
			});

			return categories;
		}

	}
}

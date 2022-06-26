using Microsoft.EntityFrameworkCore;
using Poodle.Data;
using Poodle.Data.EntityModels;
using System.Collections.Generic;

namespace Poodle.Tests
{
	public class Utils
	{
		public static ApplicationContext GetInMemoryContext()
		{
			var builder = new DbContextOptionsBuilder<ApplicationContext>()
				.UseInMemoryDatabase("TestDBContext")
				.Options;

			return new ApplicationContext(builder);
		}

		public static void SeedDatabase(ApplicationContext _context)
		{
			var users = new List<User>
			{
				new User
				{
					Password = "adminADMIN123?",
					FirstName = "Ragnar",
					LastName = "Lodbrock",
					Email = "Ragnar.Lodbrock@abv.com",
					RoleId = 1,
					ImageId = 1
				},
				new User
				{
					Password = "jondav123*",
					FirstName = "Jonathan",
					LastName = "Davis",
					Email = "Jonathan.Davis@gmail.com",
					RoleId = 2,
					ImageId = 2
				},
				new User
				{
					Password = "ignitalo123*",
					FirstName = "Ignatio",
					LastName = "Italiano",
					Email = "Ignatio.Italiano@gmail.com",
					RoleId = 2,
					ImageId = 3
				}
			};
			var profilePics = new List<Image>
			{
				new Image
				{
					ImageUrl = "/img/DefaultImage.jpg",
					UserId = 1
				},
				new Image
				{
					ImageUrl = "/img/DefaultImage.jpg",
					UserId = 2
				},
				new Image
				{
					ImageUrl = "/img/DefaultImage.jpg",
					UserId = 3
				}
			};
			var courses = new List<Course>
			{
				new Course
				{
					Title = "Implementing and Administering Solutions(CCNA)",
					Description = "The course gives you a broad range of fundamental knowledge for all IT careers. Through a combination of lecture, hands-on labs, and self-study, you will learn how to install, operate, configure, and verify basic IPv4 and IPv6 networks. The course covers configuring network components such as switches, routers, and wireless LAN controllers; managing network devices; and identifying basic security threats. The course also gives you a foundation in network programmability, automation, and software-defined networking.",
					PhotoURL = "img/course-1.jpg",
					CategoryId = 1
				},
				new Course
				{
					Title = "Developing Applications Using Core Platforms and APIs (DEVCOR)",
					Description = "The course helps you prepare for DevNet Professional certification and for professional-level network automation engineer roles. You will learn how to implement network applications using Cisco® platforms as a base, from initial software design to diverse system integration, as well as testing and deployment automation. The course gives you hands-on experience solving real world problems using Cisco Application Programming Interfaces (APIs) and modern development tools.",
					PhotoURL = "img/course-2.jpg",
					CategoryId = 1
				},
				new Course
				{
					Title = "Configuring Unified Computing System (DCCUCS)",
					Description = "The course shows you how to deploy, secure, operate, and maintain Unified Computing System™ (Cisco UCS®) B-series blade servers, Cisco UCS C-Series, and S-Series rack servers for use in data centers. You will learn how to implement management and orchestration software for Cisco UCS. You will gain hands-on practice: configuring key features of Cisco UCS, Cisco UCS Director, and Cisco UCS Manager; implementing UCS management software including Cisco UCS Manager and Cisco Intersight™; and more.",
					PhotoURL = "img/course-3.jpg",
					CategoryId = 2
				}
			};
			var sections = new List<Section>
			{
				new Section
				{

					Title = "Exploring the Functions of Networking",
					Content = "testTest",
					CourseId = 1,
					Rank = 1
				},
				new Section
				{
					Title = "Introducing the Host-to-Host Communications Model",
					Content = "testTest",
					CourseId = 1,
					Rank = 2,
				},
				new Section
				{
					Title = "Operating Cisco IOS Software",
					Content = "testTest",
					CourseId = 2,
					Rank = 1,
				},
				new Section
				{
					Title = "Designing for Maintainability",
					Content = "testTest",
					CourseId = 2,
					Rank = 2,
				},
				new Section
				{
					 Title = "Designing for Serviceability",
					Content = "testTest",
					CourseId = 3,
					Rank = 1
				},
				new Section
				{
					Title = "Implementing Cisco UCS Storage Area Network (SAN)",
					Content = "testTest",
					CourseId = 3,
					Rank = 2
				}
			};
			var roles = new List<Role>
			{
				new Role
				{
					Name = "Teacher"
				},
				new Role
				{
					Name = "Student"
				}
			};
			var categories = new List<Category>
			{
				new Category
				{
					Name = "Public"
				},
				new Category
				{
					Name = "Private"
				}
			};

			_context.Images.AddRange(profilePics);
			_context.Users.AddRange(users);
			_context.Courses.AddRange(courses);
			_context.Sections.AddRange(sections);
			_context.Roles.AddRange(roles);
			_context.Categories.AddRange(categories);
			//_context.Subscriptions.AddRange(subscriptions);
			_context.SaveChanges();
		}
	}
}

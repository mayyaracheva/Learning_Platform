using Microsoft.EntityFrameworkCore;
using Poodle.Data.EntityModels;
using System;
using System.Collections.Generic;

namespace Poodle.Data
{
    public static class ModelBuilderExtension
    {
		private static string defaultImageData = "/Images/DefaultImage.jpg";


		public static void Seed(this ModelBuilder modelBuilder)
		{			
			List<Image> Images = GetImages();
			modelBuilder.Entity<Image>().HasData(Images);

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
				UserId = 8
			});
			profileimages.Add(new Image
			{
				Id = 9,
				ImageUrl = defaultImageData,
				UserId = 9
			});
			profileimages.Add(new Image
			{
				Id = 10,
				ImageUrl = defaultImageData,
				UserId = 10
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
				Email = "Ragnar.Lodbrock@abv.com",
				RoleId = 1,
				ImageId = 1,
				CreatedOn = DateTime.UtcNow,
				ModifiedOn = DateTime.UtcNow,
				IsDeleted = false
			});
			users.Add(new User
			{
				Id = 2,
				Password = "johnJOHN123!",
				FirstName = "Jack",
				LastName = "Richmond",
				Email = "Jack.Richmond@yahoo.com",
				RoleId = 1,
				ImageId = 2,
				CreatedOn = DateTime.UtcNow,
				ModifiedOn = DateTime.UtcNow,
				IsDeleted = false
			});
			users.Add(new User
			{
				Id = 3,
				Password = "jondav123*",
				FirstName = "Jonathan",
				LastName = "Davis",
				Email = "Jonathan.Davis@gmail.com",
				RoleId = 2,
				ImageId = 3,
				CreatedOn = DateTime.UtcNow,
				ModifiedOn = DateTime.UtcNow,
				IsDeleted = false
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
				CreatedOn = DateTime.UtcNow,
				ModifiedOn = DateTime.UtcNow,
				IsDeleted = false
			});
			users.Add(new User
			{
				Id = 5,
				Password = "jamesonN123*",
				FirstName = "Reginald",
				LastName = "Hargreeves",
				Email = "Reginald.Hargreeves@gmail.com",
				RoleId = 2,
				ImageId = 5,
				CreatedOn = DateTime.UtcNow,
				ModifiedOn = DateTime.UtcNow,
				IsDeleted = false
			});
			users.Add(new User
			{
				Id = 6,
				Password = "johnsonN123*",
				FirstName = "John",
				LastName = "Hanes",
				Email = "John.Hanes@gmail.com",
				RoleId = 2,
				ImageId = 6,
				CreatedOn = DateTime.UtcNow,
				ModifiedOn = DateTime.UtcNow,
				IsDeleted = false
			});
			users.Add(new User
			{
				Id = 7,
				Password = "horspanP123*",
				FirstName = "Horatio",
				LastName = "Spanish",
				Email = "Horatio.Spanish@gmail.com",
				RoleId = 2,
				ImageId = 7,
				CreatedOn = DateTime.UtcNow,
				ModifiedOn = DateTime.UtcNow,
				IsDeleted = false
			});
			users.Add(new User
			{
				Id = 8,
				Password = "hurspenM456!",
				FirstName = "Herbert",
				LastName = "Spencer",
				Email = "Herbert.Spencer@gmail.com",
				RoleId = 2,
				ImageId = 8,
				CreatedOn = DateTime.UtcNow,
				ModifiedOn = DateTime.UtcNow,
				IsDeleted = false
			});
			users.Add(new User
			{
				Id = 9,
				Password = "hardiR789*",
				FirstName = "Harriet",
				LastName = "Dark",
				Email = "Harriet.Dark@gmail.com",
				RoleId = 2,
				ImageId = 9,
				CreatedOn = DateTime.UtcNow,
				ModifiedOn = DateTime.UtcNow,
				IsDeleted = false
			});
			users.Add(new User
			{
				Id = 10,
				Password = "marrob123!",
				FirstName = "Mario",
				LastName = "Caruso",
				Email = "Mario.Caruso@gmail.com",
				RoleId = 2,
				ImageId = 10,
				CreatedOn = DateTime.UtcNow,
				ModifiedOn = DateTime.UtcNow,
				IsDeleted = false
			});
			return users;
		}

		public static List<Course> GetCourses()
		{
			var courses = new List<Course>();

			courses.Add(new Course
			{
				Id = 1,
				Title = "Implementing and Administering Solutions(CCNA)",
				Description = "The course gives you a broad range of fundamental knowledge for all IT careers. Through a combination of lecture, hands-on labs, and self-study, you will learn how to install, operate, configure, and verify basic IPv4 and IPv6 networks. The course covers configuring network components such as switches, routers, and wireless LAN controllers; managing network devices; and identifying basic security threats. The course also gives you a foundation in network programmability, automation, and software-defined networking.",
				CategoryId = 1,
				IsDeleted = false
			});
			courses.Add(new Course
			{
				Id = 2,
				Title = "Developing Applications Using Core Platforms and APIs (DEVCOR)",
				Description = "The course helps you prepare for DevNet Professional certification and for professional-level network automation engineer roles. You will learn how to implement network applications using Cisco® platforms as a base, from initial software design to diverse system integration, as well as testing and deployment automation. The course gives you hands-on experience solving real world problems using Cisco Application Programming Interfaces (APIs) and modern development tools.",
				CategoryId = 1,
				IsDeleted = false
			});
			courses.Add(new Course
			{
				Id = 3,
				Title = "Configuring Unified Computing System (DCCUCS)",
				Description = "The course shows you how to deploy, secure, operate, and maintain Unified Computing System™ (Cisco UCS®) B-series blade servers, Cisco UCS C-Series, and S-Series rack servers for use in data centers. You will learn how to implement management and orchestration software for Cisco UCS. You will gain hands-on practice: configuring key features of Cisco UCS, Cisco UCS Director, and Cisco UCS Manager; implementing UCS management software including Cisco UCS Manager and Cisco Intersight™; and more.",
				CategoryId = 1,
				IsDeleted = false
			});
			courses.Add(new Course
			{
				Id = 4,
				Title = "Implementing Application Centric Infrastructure (DCACI)",
				Description = "The course shows you how to deploy and manage the  Nexus® 9000 Series Switches in Cisco Application Centric Infrastructure (Cisco ACI®) mode. You will learn how to configure and manage Cisco Nexus 9000 Series Switches in ACI mode, how to connect the Cisco ACI fabric to external networks and services, and the fundamentals of Virtual Machine Manager (VMM) integration. You will gain hands-on practice implementing key capabilities such as fabric discovery, policies, connectivity, VMM integration, and more.",
				CategoryId = 2,
				IsDeleted = false
			});
			courses.Add(new Course
			{
				Id = 5,
				Title = "Nexus 9000 Switches in NX-OS Mode",
				Description = "The course shows you how to implement, manage, and troubleshoot  Nexus® 9000 Series Switches in Cisco® NX-OS mode. Through expert instruction and extensive hands-on learning, you will learn how to deploy capabilities including Virtual Extensible LAN (VXLAN), Multiprotocol Label Switching (MPLS), high availability features, Intelligent Traffic Director, troubleshooting tools and techniques, NX-OS programmability features, and open interface technologies.",
				CategoryId = 2,
				IsDeleted = false
			});
			courses.Add(new Course
			{
				Id = 6,
				Title = "Multicloud Automation and Orchestration with CloudCenter Suite (CLDAO) 1.0",
				Description = "The course, Mulitcloud Automation and Orchestration with  CloudCenter Suite (CLDAO) v1.0 teaches you how to configure simplified orchestration and workflow automation that provides seamless integration within the Cisco® CloudCenter suite. Through lessons and hands-on experiences, you will learn to use the tools of the CloudCenter Suite to streamline business processes, automate tasks, and increase efficiency in business processes.",
				CategoryId = 2,
				IsDeleted = false
			});
			courses.Add(new Course
			{
				Id = 7,
				Title = "Guided Study Group - CyberOps (GSG-CBROPS) 1.0",
				Description = "A Guided Study Group offers you a 180-day journey of certification preparation. This approach offers a best-of-all-worlds path toward certification, with the flexibility and convenience of e-learning plus the motivation and accountability of working with a live coach. A mix of participants from various backgrounds and skill levels encourages collaboration.",
				CategoryId = 2,
				IsDeleted = false
			});
			courses.Add(new Course
			{
				Id = 8,
				Title = "Transforming to a Intent Based Network (IBNTRN) 1.0",
				Description = "Through a combination of lessons and hands-on learning, you will practice operating, managing, and integrating Cisco DNA Center, programmable network infrastructure, and Cisco SD-Access fundamentals. You will learn how Cisco delivers intent-based networking across the campus, branch, WAN, and extended enterprise and ensures that your network is operating as intended.",
				CategoryId = 2,
				IsDeleted = false
			}); courses.Add(new Course
			{
				Id = 9,
				Title = "Microsoft Azure Fundamentals: Describe core Azure services",
				Description = "In this module, you'll learn how to take advantage of several virtualization services in Azure compute, which can help your applications scale out quickly and efficiently to meet increasing demands.",
				CategoryId = 1,
				IsDeleted = false
			}); courses.Add(new Course
			{
				Id = 10,
				Title = "Automate development tasks by using GitHub Actions",
				Description = "Create a basic GitHub Action and use that action in a workflow.",
				CategoryId = 1,
				IsDeleted = false
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
				Content = "",
				CourseId = 1,
				Rank = 1,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 2,
				Title = "Introducing the Host-to-Host Communications Model",
				CourseId = 1,
				Rank = 2,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 3,
				Title = "Operating Cisco IOS Software",
				CourseId = 1,
				Rank = 3,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 4,
				Title = "Designing for Maintainability",
				CourseId = 2,
				Rank = 1,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 5,
				Title = "Designing for Serviceability",
				CourseId = 2,
				Rank = 2,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 6,
				Title = "Describing Advanced REST API Integration",
				CourseId = 2,
				Rank = 3,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 7,
				Title = "Implementing Cisco UCS Storage Area Network (SAN)",
				CourseId = 3,
				Rank = 1,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 8,
				Title = "Implementing External Authentication Providers",
				CourseId = 3,
				Rank = 2,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 9,
				Title = "Describing Cisco UCS Policies for Service Profiles",
				CourseId = 3,
				Rank = 3,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 10,
				Title = "Ethernet switching products",
				CourseId = 4,
				Rank = 1,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 11,
				Title = "Data center architecture",
				CourseId = 4,
				Rank = 2,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 12,
				Title = "Understanding of networking protocols, routing, and switching",
				CourseId = 4,
				Rank = 3,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 13,
				Title = "Data Center Trends",
				CourseId = 5,
				Rank = 1,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 14,
				Title = "Describing Nexus 9000 Series Hardware",
				CourseId = 5,
				Rank = 2,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 15,
				Title = "Nexus 9000 NX-OS Features",
				CourseId = 5,
				Rank = 3,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 16,
				Title = "Introducing CloudCenter Suite Action Orchestrator",
				CourseId = 6,
				Rank = 1,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 17,
				Title = "CloudCenter Suite Architecture",
				CourseId = 6,
				Rank = 2,
				IsDeleted = false
			});
			sections.Add(new Section
			{
				Id = 18,
				Title = "Defining Action Orchestrator User Management and Security Considerations",
				CourseId = 6,
				Rank = 3,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 19,
				Title = "Identifying Security Concepts",
				CourseId = 7,
				Rank = 1,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 20,
				Title = "Defining the Security Operations Center",
				CourseId = 7,
				Rank = 2,
				IsDeleted = false,
				IsRestricted = false
			}); 
			sections.Add(new Section
			{
				Id = 21,
				Title = "SOC Analyst tools",
				CourseId = 7,
				Rank = 3,
				IsDeleted = false,
				IsRestricted = false
			}); 
			sections.Add(new Section
			{
				Id = 22,
				Title = "Introducing DNA Architecture",
				CourseId = 8,
				Rank = 1,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 23,
				Title = "Deploy Wired Fabric Networks with DNA Center",
				CourseId = 8,
				Rank = 2,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 24,
				Title = "Deploy Brownfield and Fabric Wireless Network with DNA Center",
				CourseId = 8,
				Rank = 3,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 25,
				Title = "Introduction",
				CourseId = 9,
				Rank = 1,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 26,
				Title = "Overview of Azure compute services",
				CourseId = 9,
				Rank = 2,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 27,
				Title = "Decide when to use Azure Virtual Machines",
				CourseId = 9,
				Rank = 3,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 28,
				Title = "Introduction",
				CourseId = 10,
				Rank = 1,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 29,
				Title = "How does GitHub Actions automate development tasks?",
				CourseId = 10,
				Rank = 2,
				IsDeleted = false,
				IsRestricted = false
			});
			sections.Add(new Section
			{
				Id = 30,
				Title = "Identify the components of GitHub Actions",
				CourseId = 10,
				Rank = 3,
				IsDeleted = false,
				IsRestricted = false
			});

			return sections;
		}

		public static List<Role> GetRoles()
		{
			var roles = new List<Role>();
			
			roles.Add(new Role
			{
				Id = 1,
				Name = "Teacher"
			});
			roles.Add(new Role
			{
				Id = 2,
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
				Name = "Restricted"
			});

			return categories;
		}

	}
}

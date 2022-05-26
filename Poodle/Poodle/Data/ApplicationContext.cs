﻿using Microsoft.EntityFrameworkCore;
using Poodle.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Data
{
    public class ApplicationContext : DbContext
    {
		public ApplicationContext()
		{

		}
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{

		}

		public DbSet<User> Users { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Section> Sections { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Role> Roles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder
			.Entity<User>()
			.HasIndex(u => u.Email)
			.IsUnique();

			modelBuilder
			.Entity<Course>()
			.HasIndex(c => c.Title)
			.IsUnique();

			modelBuilder.Seed();
		}
    }
}

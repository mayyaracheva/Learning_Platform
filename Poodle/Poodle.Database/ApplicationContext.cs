using Microsoft.EntityFrameworkCore;
using Poodle.Database.Data;
using Poodle.Database.EntityModels;

namespace Poodle.Database.Database
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

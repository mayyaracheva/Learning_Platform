using Microsoft.EntityFrameworkCore;
using Poodle.Data.EntityModels;
using Poodle.Data.EntityModels.Contracts;
using System.Linq;
using System.Threading;
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
		public DbSet<Image> Images { get; set; }

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

		public override int SaveChanges()
		{
			ChangeTracker.DetectChanges();
			OnBeforeSaving();
			return base.SaveChanges();
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			ChangeTracker.DetectChanges();
			OnBeforeSaving();
			return base.SaveChangesAsync();
		}

		private void OnBeforeSaving()
		{
			foreach (var entry in ChangeTracker.Entries<IDeletable>())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.CurrentValues["IsDeleted"] = false;						
						break;

					case EntityState.Deleted:
						entry.State = EntityState.Modified;
						entry.CurrentValues["IsDeleted"] = true;
						break;
				}
			}
		}



	}
}

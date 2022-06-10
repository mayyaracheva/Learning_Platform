using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Poodle.Services.Helpers;
using Poodle.Services.Mappers;
using Poodle.Services.Services;
using Poodle.Data;
using Poodle.Repositories;
using Poodle.Repositories.Contracts;
using Poodle.Services.Contracts;

namespace Poodle.Services
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// add services to the DI container
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddControllers().AddNewtonsoftJson(
				options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
			
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Poodle.API", Version = "v1" });
			});

			//helpers 
			services.AddTransient<UserMapper>();
			services.AddTransient<CourseMapper>();
			services.AddTransient<SectionMapper>();
			services.AddTransient<AuthenticationHelper>();
			services.AddTransient<ExceptionHandlingMiddleware>();//error handling step 2

			//repositories
			services.AddScoped<ICoursesRepository, CoursesRepository>();
			services.AddScoped<IUsersRepository, UsersRepository>();
			services.AddScoped<ISectionRepository, SectionRepository>();


			// configure DI for application services
			services.AddScoped<IUsersService, UsersService>();
			services.AddScoped<ISectionService, SectionService>();
			services.AddScoped<ICoursesService, CoursesService>();
			services.AddScoped<IHomeService, HomeService>();
			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				// generated swagger json and swagger ui middleware
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Poodle.API v1"));
			}
			// migrate database changes on startup (includes initial db creation)
			//context.Database.Migrate();

			app.UseRouting();

			// global error handler
			app.UseMiddleware<ExceptionHandlingMiddleware>(); //error handling step 3
			//app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Poodle.Data;
using Poodle.Repositories;
using Poodle.Repositories.Contracts;
using Poodle.Services;
using Poodle.Services.Contracts;
using Poodle.Services.Mappers;
using Poodle.Services.Services;
using Poodle.Web.Helpers;

namespace Poodle.Web
{
	public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
           
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSession(options =>
            {
                options.IdleTimeout = System.TimeSpan.FromSeconds(1000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //helpers 
            services.AddTransient<UserMapper>();
            services.AddTransient<CourseMapper>();
            services.AddTransient<AuthHelper>();
            services.AddTransient<SectionMapper>();

            //repositories
            services.AddScoped<ICoursesRepository, CoursesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();


            //services
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<ICoursesService, CoursesService>();
            services.AddScoped<IHomeService, HomeService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();               
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

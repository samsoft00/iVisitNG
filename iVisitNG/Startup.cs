using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using iVisitNG.Data;
using iVisitNG.Models;
using iVisitNG.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace iVisitNG
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("iVisitNGConnectionn")));

            services.AddIdentity<Staff, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<Vereyon.Web.IFlashMessage, Vereyon.Web.FlashMessage>();

            // Add MVC services to the services container.
            services.AddMvc();
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Dashboard}/{action=Index}/{id?}");
            });

            CreateRoles(provider).Wait();
        }

        //The method below create roles
        private async Task CreateRoles(IServiceProvider provider)
        {
            var RoleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = provider.GetRequiredService<UserManager<Staff>>();

            string[] roleNames = { "Admin", "Staff", "Security" };

            IdentityResult roleResult;

            foreach(var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);

                if (!roleExist){
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }

            }

            string username = Configuration.GetSection("UserSettings")["UserEmail"];
            string password = Configuration.GetSection("UserSettings")["UserPassword"];

            //creating a super user who will maintain the application
            var powerUser = new Staff
            {
                UserName = username,
                Email = username
            };

            var _user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);
            if(_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(powerUser, password);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the Admin role
                    await UserManager.AddToRoleAsync(powerUser, "Admin");
                }
            }


        }
    }
}

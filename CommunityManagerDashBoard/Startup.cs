using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommunityManagerDashBoard.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CommunityManagerDashBoard.Data.Repositories;
using CommunityManagerDashBoard.Models.Configuration;


namespace CommunityManagerDashBoard
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<Factory>();
            services.AddIdentity<IdentityUser,IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<TwillioAccountDetails>(Configuration.GetSection("TwilioAccountDetails"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateRoles(serviceProvider).Wait();

        }

        public async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "Administration", "Manager" };

            IdentityResult roleResult;

            foreach (var role in roles)
            {
                var roleCall = await RoleManager.RoleExistsAsync(role);

                if (!roleCall)
                {

                    roleResult = await RoleManager.CreateAsync(new IdentityRole(role));
                }

                var adminUser = new IdentityUser
                {
                    Email = "AdministrationEmail"

                };

                var user = await UserManager.FindByEmailAsync("AdministrationEmail");

                if (user == null)
                {

                    var createAdminUser = await UserManager.CreateAsync(adminUser);
                    if (createAdminUser.Succeeded)
                    {
                        await UserManager.AddToRoleAsync(adminUser, "Administration");
                    }
                }

                var managerUser = new IdentityUser
                {

                    Email = "ManagerEmail"

                };

                var anotherUser = await UserManager.FindByEmailAsync("ManagerEmail");

                if (anotherUser == null)
                {

                    var createMangerUser = await UserManager.CreateAsync(managerUser);

                    if (createMangerUser.Succeeded)
                    {
                        await UserManager.AddToRoleAsync(managerUser, "Manager");
                    }
                }
            }
        }





    }
}


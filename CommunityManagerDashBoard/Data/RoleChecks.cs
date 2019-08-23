using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extentions.Configuration;
using Microsoft.Extentions.DependencyInjection;

namespace CommunityManagerDashBoard.Data
{
    public class RoleChecks
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        { 
            //add custom roles
         var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
         var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

         string[] roleNames = { "Amin", "Manager" };
         IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                //create the roles and seed them to database

                var roleExist = await RoleManager.RoleExistAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }

            }

            //create a user that can maintain web app
            var administratorUser = new ApplicationUser
            {
                UserName = Configuration.GetSection("UserSettngs")["AdminEmail"],
                Email = Configuration.GetSection("UserSettings")["AdminEmail"]
            };

            string userPassWord = Configuration.GetSection("UserSettings")["AdminPassword"];

            var user = await UserManager.FindByEmailAsync(Configuration.GetSection(("UserSettings")["AdminEmail"]));


            if(user == null)
            {
                var createAdministratorUser = await UserManager.CreateAsync(administratorUser, userPassWord);

                if (createAdministratorUser.Succeeded)
                {
                    //assign the new user as Admin
                    await UserManager.AddToRoleAsync(AdministratorUser, "Admin");
                }
            }

            var managerUser = new ApplicationUser
            {
                UserName = Configuration.GetSection("UserSettngs")["ManageEmail"],
                Email = Configuration.GetSection("UserSettings")["ManageEmail"]
            };

            string userPassWord = Configuration.GetSection("UserSettings")["ManagePassword"];

            var user = await UserManager.FindByEmailAsync(Configuration.GetSection(("UserSettings")["ManageEmail"]));


            if (user == null)
            {
                var createManagerUser = await UserManager.CreateAsync(managerUser, userPassWord);

                if (createManagerUser.Succeeded)
                {
                    //assign the new user as Admin
                    await UserManager.AddToRoleAsync(managerUser, "Manager");
                }
            }
        }
    }
}

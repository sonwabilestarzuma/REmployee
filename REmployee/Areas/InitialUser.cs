using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using REmployee.Data;
using REmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REmployee.Areas
{
    public class InitialUser
    {
        // This will create a user with an Admin role when the application runs for the first time.
        // It will also create the only two roles the users will have for this application, namely Admin and User role.

        public async static void Initialize(IServiceProvider serviceProvider)
        {
            var _dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            _dbContext.Database.EnsureCreated();

            if (!_dbContext.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "Admin",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Email = "admin@media24.com"
                };

                // Create Admin user
                var result = await userManager.CreateAsync(user, "P@ssw0rd");
                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync("Admin"))
                    {
                        // Create Admin role and apply it to the Admin user
                        var adminRole = new ApplicationRole("Admin");

                        var res = await roleManager.CreateAsync(adminRole);
                        if (res.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, "Admin");
                        }

                        // Create User role
                        var userRole = new ApplicationRole("User");
                        await roleManager.CreateAsync(userRole);
                    }
                }
            }

        }
    }
}

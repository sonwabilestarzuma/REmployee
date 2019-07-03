using Microsoft.AspNetCore.Identity;
using REmployee.Data;
using REmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace UserIdentityCore.Data
{
    public class DummyData
    {
        public static async Task Initialize(ApplicationDbContext context,
                             UserManager<REmployee.Models.ApplicationUser> userManager,
                             RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";
            String adminId2 = "";

            // for administration role
            string role1 = "Admin";
            string desc1 = "This is the administrator role";

            // this for a user role 
            string role2 = "Member";
            string desc2 = "This is the members role";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("aa@aa.com") == null)
            {
                var user = new REmployee.Models.ApplicationUser
                {
                    UserName = "aa@aa.com",
                    Email = "aa@aa.com",
                    Employee = new Employee
                    {
                        FirstName = "Star",
                        Surname = "Zuma",
                        UserRole = "Admin",
                        DateOfBirth = new DateTime(1965, 6, 4),
                        Email = "sonwabilezuma@gmail.com",
                        TitleId = 1,
                        EmployeeStatusId = 1,
                        EmployeeStatus = new EmployeeStatus
                        {
                            Status = "True"
                        },
                         Title = new Title
                         {
                             JobTitle = "Software Developer"
                         }
                    },

                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }

            if (await userManager.FindByNameAsync("bb@bb.com") == null)
            {

                var user = new REmployee.Models.ApplicationUser
                {
                    UserName = "bb@bb.com",
                    Email = "bb@bb.com",
                    Employee = new Employee
                    {
                        FirstName = "Lucky",
                        Surname = "Lutho",
                        UserRole = "Admin",
                        DateOfBirth = new DateTime(1999, 6, 4),
                        Email = "sonwabilezuma@gmail.com",
                        TitleId = 1,
                        EmployeeStatusId = 1,
                        EmployeeStatus = new EmployeeStatus
                        {
                            Status = "True"
                        },
                        Title = new Title
                        {
                            JobTitle = "Engineer Developer"
                        }
                    },

                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("mm@mm.com") == null)
            {
                var user = new REmployee.Models.ApplicationUser
                {
                    UserName = "mm@mm.com",
                    Email = "mm@mm.com",
                    Employee = new Employee
                    {
                        FirstName = "Dacy",
                        Surname = "Victory",
                        UserRole = "User",
                        DateOfBirth = new DateTime(1944, 2, 6),
                        Email = "sonwabilezuma@gmail.com",
                        TitleId = 1,
                        EmployeeStatusId = 1,
                        EmployeeStatus = new EmployeeStatus
                        {
                            Status = "False"
                        },
                        Title = new Title
                        {
                            JobTitle = "Teacher"
                        }
                    },

                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }

            if (await userManager.FindByNameAsync("dd@dd.com") == null)
            {
                var user = new REmployee.Models.ApplicationUser
                {

                    UserName = "dd@dd.com",
                    Email = "dd@dd.com",
                    Employee = new Employee
                    {
                        FirstName = "Rio",
                        Surname = "Riona",
                        UserRole = "User",
                        DateOfBirth = new DateTime(1975, 6, 4),
                        Email = "sonwabilezuma@gmail.com",
                        TitleId = 1,
                        EmployeeStatusId = 1,
                        EmployeeStatus = new EmployeeStatus
                        {
                            Status = "True"
                        },
                        Title = new Title
                        {
                            JobTitle = "Plumber"
                        }
                    },

                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }
        }
    }
}
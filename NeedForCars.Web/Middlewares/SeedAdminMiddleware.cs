using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NeedForCars.Data;
using NeedForCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.Middlewares
{
    public class SeedAdminMiddleware
    {
        private const string ROLE_ADMIN = "Admin";

        private readonly RequestDelegate _next;

        public SeedAdminMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<NeedForCarsUser> userManager,
                                      RoleManager<IdentityRole> roleManager, NeedForCarsDbContext db)
        {
            SeedRoles(roleManager).GetAwaiter().GetResult();

            SeedUserInRoles(userManager).GetAwaiter().GetResult();

            await _next(context);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(ROLE_ADMIN))
            {
                await roleManager.CreateAsync(new IdentityRole(ROLE_ADMIN));
            }
        }

        private static async Task SeedUserInRoles(UserManager<NeedForCarsUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new NeedForCarsUser
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    EmailConfirmed = true,
                    PhoneNumber = "0000000000",
                    LockoutEnabled = false,

                    ReceivedMessages = new HashSet<Message>(),
                    SentMessages = new HashSet<Message>(),
                    UserCars = new HashSet<UserCar>()
                };

                var password = "givemecars";

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, ROLE_ADMIN);
                }
            }
        }
    }
}

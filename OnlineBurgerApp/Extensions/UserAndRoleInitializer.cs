using OnlineBurgerApp.Data;
using OnlineBurgerApp.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace OnlineBurgerApp.Extensions
{
    public static class UserAndRoleInitializer
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var dbContext = services.GetService<ApplicationDbContext>();


                dbContext.Database.Migrate();

                var roleManager = services.GetService<RoleManager<IdentityRole>>();
                var existingRole = roleManager.FindByNameAsync("Administrators");
                if (existingRole != null)
                {
                    return app;
                }

                var adminRole = new IdentityRole("Administrators");

                roleManager.CreateAsync(adminRole);

                var adminUser = new ApplicationUser
                {
                    UserName = "admin@blog.com",
                    Email = "admin@blog.com",
                    SecurityStamp = "RandomSecurityStamp"
                };

                var userManager = services.GetService<UserManager<ApplicationUser>>();

                userManager.CreateAsync(adminUser, "adminpass");

                userManager.AddToRoleAsync(adminUser, "Administrators");

                dbContext.SaveChanges();
                return app;
            }

        }

    }
}

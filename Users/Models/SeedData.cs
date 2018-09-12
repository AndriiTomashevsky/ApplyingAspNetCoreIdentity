using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Users.Models;
using Microsoft.AspNetCore.Identity;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .GetRequiredService<AppIdentityDbContext>();
            UserManager<AppUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<AppUser>>();

            context.Database.Migrate();

            if (!await context.Users.AnyAsync())
            {
                AppUser joe = new AppUser { UserName = "Joe", Email = "joe@example.com", };
                AppUser alice = new AppUser { UserName = "Alice", Email = "alice@example.com", };
                AppUser bob = new AppUser { UserName = "Bob", Email = "bob@example.com", };

                await userManager.CreateAsync(joe, "secret123");
                await userManager.CreateAsync(alice, "secret123");
                await userManager.CreateAsync(bob, "secret123");
            }

            context.SaveChanges();
        }
    }
}

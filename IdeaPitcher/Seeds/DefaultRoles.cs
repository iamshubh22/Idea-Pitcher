using IdeaPitcher.Constants;
using IdeaPitcher.DAL.Data;
using Microsoft.AspNetCore.Identity;
using System.Data;


namespace IdeaPitcher.Seeds
{ 
        public static class DefaultRoles
        {
            public static async Task SeedAsync(UserManager<IdeaPitcherUser> userManager, RoleManager<IdentityRole> roleManager)
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Leader.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
            }
        }
    
}

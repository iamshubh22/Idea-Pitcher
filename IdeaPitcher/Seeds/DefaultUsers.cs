using Microsoft.AspNetCore.Identity;
using IdeaPitcher.Constants;
using System.Security.Claims;
using IdeaPitcher.DAL.Data;

namespace IdeaPitcher.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedBasicUserAsync(UserManager<IdeaPitcherUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new IdeaPitcherUser
            {
                UserName = "basicuser@amity.edu",
                Email = "basicuser@amity.edu",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }
            }
        }

        public static async Task SeedLeaderAsync(UserManager<IdeaPitcherUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new IdeaPitcherUser
            {
                UserName = "Leader@amity.edu",
                Email = "Leader@amity.edu",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,

            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Leader.ToString());
                }
            }
            await roleManager.SeedClaimsForLeader();
        }

        public static async Task SeedSuperAdminAsync(UserManager<IdeaPitcherUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new IdeaPitcherUser
            {
                UserName = "superadmin@amity.edu",
                Email = "superadmin@amity.edu",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Leader.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                }
                await roleManager.SeedClaimsForSuperAdmin();
            }
        }

        private async static Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
            await roleManager.AddPermissionClaim(adminRole, "AccessIdea");
        }

        private async static Task SeedClaimsForLeader(this RoleManager<IdentityRole> roleManager)
        {
            var leaderRole = await roleManager.FindByNameAsync("Leader");
            await roleManager.AddPermissionClaim(leaderRole, "AccessIdea");
        }

        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
    }
}

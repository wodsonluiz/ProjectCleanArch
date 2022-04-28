using Microsoft.AspNetCore.Identity;
using ProjectCleanArch.Data.Context;
using ProjectCleanArch.Domain.Auth;
using System;

namespace ProjectCleanArch.Data.Identity
{
    public class SeedUserRoleInitialService : ISeedUserRoleInitial
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedUserRoleInitialService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void SeedRoles()
        {
            var hasRoleUser = _roleManager.RoleExistsAsync("User").Result;
            var hasRoleAdmin = _roleManager.RoleExistsAsync("Admin").Result;

            if (!hasRoleUser)
            {
                var role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                _ = _roleManager.CreateAsync(role).Result;
            }

            if (!hasRoleAdmin)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                _ = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            var hasUser = _userManager.FindByEmailAsync("usuario@localhost").Result;
            var hasAdmin = _userManager.FindByEmailAsync("admin@localhost").Result;

            if (hasUser == null)
            {
                var user = new ApplicationUser();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                var result = _userManager.CreateAsync(user, "Numero#2021").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (hasAdmin == null)
            {
                var user = new ApplicationUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                var result = _userManager.CreateAsync(user, "Numero#2021").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}

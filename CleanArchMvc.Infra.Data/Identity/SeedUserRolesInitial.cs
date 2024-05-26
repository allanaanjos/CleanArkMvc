using System;
using CleanArchMvc.Domain.Accont;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class SeedUserRolesInitial : ISeedUserRolesInitial
    {
        private readonly UserManager<ApplicationIdentityUser> _userManage;
        private readonly RoleManager<IdentityRole> _rolemanage;

        public SeedUserRolesInitial(UserManager<ApplicationIdentityUser> userManager,
          RoleManager<IdentityRole> roleManager)
        {
            _rolemanage = roleManager;
            _userManage = userManager;
        }
        public void SeedUsers()
        {
            if (_userManage.FindByEmailAsync("usuario@localhost").Result == null)
            {
                ApplicationIdentityUser user = new ApplicationIdentityUser();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManage.CreateAsync(user, "Numsey#2021").Result;

                if (result.Succeeded)
                {
                    _userManage.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (_userManage.FindByEmailAsync("admin@localhost").Result == null)
            {
                ApplicationIdentityUser user = new ApplicationIdentityUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManage.CreateAsync(user, "Numsey#2021").Result;

                if (result.Succeeded)
                {
                    _userManage.AddToRoleAsync(user, "Admin").Wait();
                }
            }


        }

        public void SeedRoles()
        {
              if (!_rolemanage.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _rolemanage.CreateAsync(role).Result;
            }
            if (!_rolemanage.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _rolemanage.CreateAsync(role).Result;
            }
        }
    }
}
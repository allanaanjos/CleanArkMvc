using System.Threading.Tasks;
using CleanArchMvc.Domain.Accont;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationIdentityUser> _userManage;
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;

        public AuthenticateService(SignInManager<ApplicationIdentityUser> signInManager,
        UserManager<ApplicationIdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManage = userManager;
        }
        public async Task<bool> AuthenticateUser(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password,
               false, lockoutOnFailure: false);

            return result.Succeeded;

        }
        public async Task<bool> RegistreUser(string email, string password)
        {
            var ApplicationIdentityUser = new ApplicationIdentityUser
            {
                UserName = email,
                Email = email
            };

            var result = await _userManage.CreateAsync(ApplicationIdentityUser, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(ApplicationIdentityUser, isPersistent: false);
            }

            return result.Succeeded;
        }

        public Task Logout()
        {
            return _signInManager.SignOutAsync();
        }

    }
}
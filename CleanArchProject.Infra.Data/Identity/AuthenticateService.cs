using CleanArchProject.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchProject.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticateService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<bool> Authenticate(string email, string passowrd)
        {
            var result = await _signInManager.PasswordSignInAsync(email,
                passowrd, false, false);
            return result.Succeeded;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(string email, string passowrd)
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = email;
            user.Email = email;
            user.NormalizedUserName = email.ToUpper();
            user.NormalizedEmail = email.ToUpper();
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            var result = _userManager.CreateAsync(user, passowrd).Result;
            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, "User");

            if (result.Succeeded)
                await _signInManager.SignInAsync(user, isPersistent: false);

            return result.Succeeded;
        }
    }
}

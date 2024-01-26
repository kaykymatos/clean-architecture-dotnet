using CleanArchProject.Domain.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email
            };
            var result = await _userManager.CreateAsync(applicationUser);
            if (result.Succeeded)
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
            
            return result.Succeeded;
        }
    }
}

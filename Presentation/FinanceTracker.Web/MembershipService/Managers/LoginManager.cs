using FinanceTracker.Data.Entities;
using FinanceTracker.Web.MembershipService.Interfaces;
using FinanceTracker.Web.Models.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTracker.Web.MembershipService.Managers
{
    public class LoginManager : ILoginService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userInManager;
        SignInResult signInResult;

        public LoginManager(SignInManager<AppUser> signInManager,
                            UserManager<AppUser> userInManager)
        {
            _signInManager = signInManager;
            _userInManager = userInManager;
        }

        public async Task<SignInResult> Login(LoginViewModel loginViewModel)
        {
            var hasUser = await _userInManager.FindByEmailAsync(loginViewModel.Email);
            if (hasUser != null)
            {
                signInResult = await _signInManager.PasswordSignInAsync(hasUser, loginViewModel.Password, false, false);
            }
            return signInResult;

        }
    }
}

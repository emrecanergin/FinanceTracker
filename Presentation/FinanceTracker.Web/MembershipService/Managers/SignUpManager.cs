using ExpenseTracker.UserOperations.DataTransferObjects;
using FinanceTracker.Data.Entities;
using FinanceTracker.Web.MembershipService.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTracker.Web.MembershipService.Managers
{
    public class SignUpManager : IRegisterService
    {
        private readonly UserManager<AppUser> _userManager;

        public SignUpManager(UserManager<AppUser> userManager)
        {
            _userManager = userManager;       
        }
        public async Task<IdentityResult> SignUp(UserDto user)
        {
            AppUser appUser = new()
            {
              Email = user.Email,
              UserName = user.UserName,
            };
            return await _userManager.CreateAsync(appUser, user.Password);
        }
    }
}

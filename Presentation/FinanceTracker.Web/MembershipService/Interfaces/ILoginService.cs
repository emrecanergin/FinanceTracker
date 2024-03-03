using FinanceTracker.Web.Models.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;

namespace FinanceTracker.Web.MembershipService.Interfaces
{
    public interface ILoginService
    {
        Task<SignInResult> Login(LoginViewModel signInViewModel); 
    }
}

using ExpenseTracker.UserOperations.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace FinanceTracker.Web.MembershipService.Interfaces
{
    public interface IRegisterService
    {
        Task<IdentityResult> SignUp(UserDto user);
    }
}

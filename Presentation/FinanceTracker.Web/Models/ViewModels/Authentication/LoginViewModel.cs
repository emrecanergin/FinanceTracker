using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinanceTracker.Web.Models.ViewModels.Authentication
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "Wrong format")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}

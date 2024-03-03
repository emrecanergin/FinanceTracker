using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinanceTracker.Web.Models.ViewModels.Authentication
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("User Name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "Wrong format")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords are not matching")]
        [DisplayName("PasswordConfirm")]
        public string PasswordConfirm { get; set; }
    }
}

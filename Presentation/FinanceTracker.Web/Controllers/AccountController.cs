using FinanceTracker.Data.Entities;
using FinanceTracker.Web.MembershipService.Interfaces;
using FinanceTracker.Web.Models.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(ILoginService loginService,
                                 SignInManager<AppUser> signInManager)
        {
            _loginService = loginService;
            _signInManager = signInManager;
        }

        [Route("/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel signInViewModel)
        {
            if (ModelState.IsValid)
            {
                //returnUrl = returnUrl ?? Url.Action("Index", "Home");
                var result = await _loginService.Login(signInViewModel);

                if (result == null)
                {
                    ModelState.AddModelError("loginFail", "Incorrect Username or Password");
                    return View(signInViewModel);
                }
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("loginFail", "Incorrect Username or Password");
                    return View(signInViewModel);
                }
            }
            return View(signInViewModel);

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //return View("Landing/Index");
            return RedirectToAction("Index", "Landing");
        }   
    }
}

using AutoMapper;
using ExpenseTracker.UserOperations.DataTransferObjects;
using FinanceTracker.Data.Context;
using FinanceTracker.Data.Entities;
using FinanceTracker.Data.Entities.StockEntities;
using FinanceTracker.Data.Repositories.EntityFramework.Abstract;
using FinanceTracker.Data.Repositories.EntityFramework.Concrete;
using FinanceTracker.Web.MembershipService.Interfaces;
using FinanceTracker.Web.Models.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanceTracker.Web.Controllers
{
    [Route("/signup")]
    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;
		private readonly IMapper _mapper;
        public RegisterController(IRegisterService registerService,                
							      IMapper mapper)
        {
            _registerService = registerService;
            _mapper = mapper;  
        }

        [HttpGet]
        public IActionResult SignUpAsync()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SignUpAsync(SignUpViewModel signUpViewModel)
        {
            if (!ModelState.IsValid)
                return View();
            UserDto userDto = new();
            var data = _mapper.Map(signUpViewModel, userDto);
            var result = await _registerService.SignUp(data);
            if (result.Succeeded)
            {              
                return RedirectToAction("Login","Account");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }
            return View();
        }
    }
}

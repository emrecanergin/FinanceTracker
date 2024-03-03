using AutoMapper;
using FinanceTracker.Business.DataTransferObjects.Coin;
using FinanceTracker.Business.Services.PortfolioService.CoinPortfolioService.Abstract;
using FinanceTracker.Data.Entities;
using FinanceTracker.Data.Entities.CoinEntities;
using FinanceTracker.Data.Entities.StockEntities;
using FinanceTracker.Data.Repositories.EntityFramework.Abstract;
using FinanceTracker.Web.Models.ViewModels.Coin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinanceTracker.Web.Controllers
{
	[Authorize]
	public class CoinPortfolioController(UserManager<AppUser> userManager,
										  ICoinPortfolioService coinPortfolioService,
										  IBaseRepository<Coin> baseRepository,
										  IMapper mapper) : Controller
	{
		[HttpGet]
		public async Task<IActionResult> ListPortfolios()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var user = await userManager.Users.Include(x => x.CoinPortfolio).FirstOrDefaultAsync(x => x.Id == userId);
			return View(user.CoinPortfolio.ToList());
		}

		[HttpGet]
		public async Task<IActionResult> ViewPortfolio(string id)
		{
			var portfolio = await coinPortfolioService.GetPortfolioByCode(id);
			return View(portfolio);
		}

		[HttpGet]
		public Task<IActionResult> AddPortfolio()
		{
			return Task.FromResult<IActionResult>(View());
		}

		[HttpPost]
		public async Task<IActionResult> AddPortfolio(string name)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var user = await userManager.FindByIdAsync(userId);
			var portfolio = await coinPortfolioService.AddCoinPortfolio(user, name);
			return RedirectToAction("ViewPortfolio", new RouteValueDictionary(new { controller = "StockPortfolio", action = "ViewPortfolio", Id = portfolio.PortfolioCode }));
		}

		
		[HttpDelete]
		public async Task<IActionResult> RemoveFromPortfolio(int assetId)
		{
			await coinPortfolioService.RemoveFromPortfolio(assetId);
			return Json(new { Success = true });
		}


		[HttpGet]
		public async Task<IActionResult> AddToPortfolio(string portfolioCode)
		{
			TempData["portfolioCode"] = portfolioCode;
			var coins = await baseRepository.GetAll();
			ViewBag.coins = coins;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddToPortfolio(CoinAddViewModel coinAddViewModel, string portfolioCode)
		{
			CoinAssetDto coinAssetDto = new CoinAssetDto();
			var asset = mapper.Map(coinAddViewModel, coinAssetDto);
			await coinPortfolioService.AddToPortfolio(asset, coinAddViewModel.PortfolioCode);
			return RedirectToAction("ViewPortfolio", new RouteValueDictionary(new { controller = "CoinPortfolio", action = "ViewPortfolio", Id = coinAddViewModel.PortfolioCode }));
		}
	}
}

using AutoMapper;
using FinanceTracker.Business.DataTransferObjects.Stock;
using FinanceTracker.Business.Services.PortfolioService.StockPortfolioService.Abstract;
using FinanceTracker.Data.Entities;
using FinanceTracker.Data.Entities.StockEntities;
using FinanceTracker.Data.Repositories.EntityFramework.Abstract;
using FinanceTracker.Web.Models.ViewModels.Stock;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinanceTracker.Web.Controllers
{
    [Authorize]
    public class StockPortfolioController(UserManager<AppUser> userManager,
                                          IStockPortfolioService stockPortfolioService,
                                          IBaseRepository<Stock> baseRepository,
                                          IMapper mapper) : Controller
	{                                    
        [HttpGet]
		public async Task<IActionResult> ListPortfolios()
		{		
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.Users.Include(x => x.StockPortfolio).FirstOrDefaultAsync(x => x.Id == userId);
			return View(user.StockPortfolio.ToList());
		}

        [HttpGet]
        public async Task<IActionResult> ViewPortfolio(string id)
        {
            var portfolio = await stockPortfolioService.GetPortfolioByCode(id);  
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
            var portfolio = await stockPortfolioService.AddStockPortfolio(user,name);
            return RedirectToAction("ViewPortfolio",new RouteValueDictionary(new { controller = "StockPortfolio", action = "ViewPortfolio", Id = portfolio.PortfolioCode }));
		}

        [HttpDelete]
        public async Task<IActionResult> RemoveFromPortfolio(int assetId)
        {
            await stockPortfolioService.RemoveFromPortfolio(assetId);
            return Json(new { Success = true });
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePortfolio(string portfolioCode)
        {
            await stockPortfolioService.RemovePortfolio(portfolioCode);
            return Json(new { Success = true });
        }

        [HttpGet]
        public async Task<IActionResult> AddToPortfolio(string portfolioCode)
        {
            TempData["portfolioCode"] = portfolioCode;
            var stocks = await baseRepository.GetAll();
            ViewBag.stocks = stocks;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddToPortfolio(StockAddViewModel stockAddViewModel,string portfolioCode)
        {        
            StockAssetDto stockAssetDto = new StockAssetDto();
            var asset = mapper.Map(stockAddViewModel, stockAssetDto);
            await stockPortfolioService.AddToPortfolio(asset, stockAddViewModel.PortfolioCode);
			return RedirectToAction("ViewPortfolio", new RouteValueDictionary(new { controller = "StockPortfolio", action = "ViewPortfolio", Id = stockAddViewModel.PortfolioCode }));
		}
	}
}

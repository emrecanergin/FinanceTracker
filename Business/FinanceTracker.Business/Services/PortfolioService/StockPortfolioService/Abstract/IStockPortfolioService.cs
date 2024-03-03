using FinanceTracker.Business.DataTransferObjects.Stock;
using FinanceTracker.Data.Entities;
using FinanceTracker.Data.Entities.StockEntities;
using FinanceTracker.Data.Repositories.EntityFramework.Concrete;


namespace FinanceTracker.Business.Services.PortfolioService.StockPortfolioService.Abstract
{
    public interface IStockPortfolioService
    {
        Task<StockPortfolio> AddStockPortfolio(AppUser user, string name);
        Task<StockPortfolio> GetPortfolioByCode(string code);

        Task AddToPortfolio(StockAssetDto stockAsset, string portfolioCode);
        Task RemoveFromPortfolio(int assetId);
        Task RemovePortfolio(string portfolioCode);

    }
}

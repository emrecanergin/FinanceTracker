using ExpenseTracker.Web.MembershipService.Managers;
using FinanceTracker.Business.Services.PortfolioService.CoinPortfolioService.Abstract;
using FinanceTracker.Business.Services.PortfolioService.StockPortfolioService.Abstract;
using FinanceTracker.Business.Services.PortfolioService.StockPortfolioService.Concrete;
using FinanceTracker.Data.Repositories.EntityFramework.Abstract;
using FinanceTracker.Data.Repositories.EntityFramework.Concrete;
using FinanceTracker.Web.MembershipService.Interfaces;

namespace FinanceTracker.Presentation.Extensions.ServiceExtensions
{
    public static class InternalServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			
            services.AddScoped<IRegisterService, SignUpManager>();
			services.AddScoped<ILoginService, LoginManager>();

			services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

			services.AddScoped<IStockPortfolioRepository, StockPortfolioRepository>();
			services.AddScoped<IStockPortfolioService, StockPortfolioService>();

            services.AddScoped<ICoinPortfolioRepository, CoinPortfolioRepository>();
            services.AddScoped<ICoinPortfolioService, CoinPortfolioService>();

            return services;
        }
    }
}

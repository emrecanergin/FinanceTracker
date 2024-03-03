
namespace FinanceTracker.Web.Extensions.ApplicationBuilderExtension
{
	public static class RouteExtension
	{
		public static WebApplication AddRoutes(this WebApplication app)
		{
			//StockPortfolio
			app.MapControllerRoute(
	              name: "default45",
	              pattern: "/stockPortfolio",
				  new {controller= "StockPortfolio" , action= "ListPortfolios" });

			app.MapControllerRoute(
				  name: "default1",
				  pattern: "/stockPortfolio/{id}",
				  new { controller = "StockPortfolio", action = "ViewPortfolio" });

			app.MapControllerRoute(
				  name: "default2",
				  pattern: "/addStockPortfolio",
				  new { controller = "StockPortfolio", action = "AddPortfolio" });
					
			app.MapControllerRoute(
				  name: "default3",
				  pattern: "/addToStockPortfolio",
				  new { controller = "StockPortfolio", action = "AddToPortfolio" });

            
			//CoinPortfolio
			app.MapControllerRoute(
				  name: "default4",
				  pattern: "/coinPortfolio",
				  new { controller = "CoinPortfolio", action = "ListPortfolios" });

			app.MapControllerRoute(
				  name: "default5",
				  pattern: "/coinPortfolio/{id}",
				  new { controller = "CoinPortfolio", action = "ViewPortfolio" });

			app.MapControllerRoute(
				  name: "default6",
				  pattern: "/addCoinPortfolio",
				  new { controller = "CoinPortfolio", action = "AddPortfolio" });

			app.MapControllerRoute(
				  name: "default7",
				  pattern: "/addToCoinPortfolio",
				  new { controller = "CoinPortfolio", action = "AddToPortfolio" });

			return app;
		}
	}
}

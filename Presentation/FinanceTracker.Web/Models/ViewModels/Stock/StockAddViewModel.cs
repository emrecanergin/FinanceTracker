namespace FinanceTracker.Web.Models.ViewModels.Stock
{
    public class StockAddViewModel
    {
        public string Name { get; set; }
		public string Symbol { get; set; }
		public int Quantity { get; set; }
        public decimal BuyingPrice { get; set; }
        public string PortfolioCode { get; set; }
    }
}

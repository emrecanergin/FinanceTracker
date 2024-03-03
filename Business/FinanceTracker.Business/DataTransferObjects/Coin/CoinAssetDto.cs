using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Business.DataTransferObjects.Coin
{
	public class CoinAssetDto
	{
		public string Name { get; set; }
		public string Symbol { get; set; }
		public int Quantity { get; set; }
		public decimal BuyingPrice { get; set; }
	}
}

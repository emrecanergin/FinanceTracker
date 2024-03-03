using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Business.DataTransferObjects.Stock
{
    public class StockDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal BuyinPrice { get; set; }
    }
}

using FinanceTracker.Data.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Data.Entities
{
    public class Transaction 
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public CategoryType Type { get; set; }
        public AppUser User { get; set; }
    }
}

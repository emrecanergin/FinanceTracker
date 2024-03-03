using FinanceTracker.Data.Helpers.Enums;


namespace FinanceTracker.Data.Entities
{
    public class Category 
    {
        public int Id { get; set; }
        public CategoryType Type { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}

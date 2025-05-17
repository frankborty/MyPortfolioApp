namespace MyPortfolioApp.Models
{
    public class ExpenseM
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ExpenseType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; } = string.Empty;

        public ExpenseM()
        {
            Description = string.Empty;
            ExpenseType = string.Empty;
            Amount = 0;
            Date = DateTime.Now;
            Note = string.Empty;
        }

    }
}

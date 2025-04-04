using MyPortfolioApp.Models;
using MyPortfolioApp.Utils;

namespace MyPortfolioApp.Models
{
    public class ExpenseCategoryM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ExpenseTypeM> TypeList { get; set; } = new List<ExpenseTypeM>();

        public ExpenseCategoryM()
        {
            Id = IdUtils.GetNextCategoryId();
        }
    }
}

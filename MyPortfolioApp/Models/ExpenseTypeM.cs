using MyPortfolioApp.Utils;

namespace MyPortfolioApp.Models
{
    public class ExpenseTypeM
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = string.Empty;

        public ExpenseTypeM() { 
            Id = IdUtils.GetNextTypeId();
        }

        public ExpenseTypeM(string name)
        {
            Id = IdUtils.GetNextTypeId();
            TypeName = name;
        }
    }
}

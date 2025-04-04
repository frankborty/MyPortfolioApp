namespace MyPortfolioApp.Models
{
    public class ExpenseCategoryAndTypesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<string> ExpenseTypeList { get; set; } = new List<string>();

        public ExpenseCategoryAndTypesDTO()
        {
            Id = -1;
        }
    }
}

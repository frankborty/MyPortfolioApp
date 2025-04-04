using MyPortfolioApp.Models;

namespace MyPortfolioApp.Utils
{
    internal static class GeneralUtils
    {
        internal static void CheckExpense(ExpenseM expense)
        {
            if (string.IsNullOrWhiteSpace(expense.Description))
            {
                throw new Exception("Inserire descrizione");
            }
            if (expense.ExpenseType is null)
            {
                throw new Exception("Inserire tipo");
            }
            if (expense.Amount <= 0)
            {
                throw new Exception("Importo non valido");
            }
        }
    }
}

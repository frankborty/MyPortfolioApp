using MyPortfolioApp.Constants;
using MyPortfolioApp.Models;
using System.Text.Json;

namespace MyPortfolioApp.Utils
{
    internal static class StorageUtils
    {

        public static void DeleteExpenseStorageFile()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, AppConstants.ExpenseListFileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public static void DeleteExpenseCategoryStorageFile()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, AppConstants.ExpenseCategoryListFileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void WriteExpenseToFile(ExpenseM expense)
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, AppConstants.ExpenseListFileName);
            File.AppendAllText(filePath, JsonSerializer.Serialize(expense) + Environment.NewLine);
        }

        public static async Task WriteExpenseCategoryListToFile(List<ExpenseCategoryAndTypesDTO> expenseCategoryList)
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, AppConstants.ExpenseCategoryListFileName);
            await File.AppendAllTextAsync(filePath, JsonSerializer.Serialize(expenseCategoryList));
        }

        public static List<ExpenseM> ReadExpenseListFromFile()
        {
            List<ExpenseM> expenseList = new List<ExpenseM>();
            string filePath = System.IO.Path.Combine(FileSystem.AppDataDirectory, AppConstants.ExpenseListFileName);
            if (!File.Exists(filePath))
            {
                return new List<ExpenseM>();
            }
            string[] jsonLines = File.ReadAllLines(filePath); // Legge il contenuto del file
            if (jsonLines is null || jsonLines.Length == 0)
            {
                return expenseList;
            }
            foreach (string line in jsonLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                ExpenseM? expense = JsonSerializer.Deserialize<ExpenseM>(line);
                if (expense is not null)
                {
                    expenseList.Add(expense);
                }
            }
            return expenseList;
        }

        public static async Task<List<ExpenseM>> ReadExpenseListFromFileAsync()
        {
            List<ExpenseM> expenseList = new List<ExpenseM>();
            string filePath = System.IO.Path.Combine(FileSystem.AppDataDirectory, AppConstants.ExpenseListFileName);
            if (!File.Exists(filePath))
            {
                return new List<ExpenseM>();
            }
            string[] jsonLines = await File.ReadAllLinesAsync(filePath); // Legge il contenuto del file
            if (jsonLines is null || jsonLines.Length == 0)
            {
                return expenseList;
            }
            foreach (string line in jsonLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                ExpenseM? expense = JsonSerializer.Deserialize<ExpenseM>(line);
                if (expense is not null)
                {
                    expenseList.Add(expense);
                }
            }
            return expenseList;
        }

        public static List<ExpenseCategoryAndTypesDTO> ReadExpenseCategoryListFromFile()
        {
            List<ExpenseCategoryAndTypesDTO> expenseCategoryList = new List<ExpenseCategoryAndTypesDTO>();
            string filePath = Path.Combine(FileSystem.AppDataDirectory, AppConstants.ExpenseCategoryListFileName);
            if (!File.Exists(filePath))
            {
                return new List<ExpenseCategoryAndTypesDTO>();
            }
            string jsonLines = File.ReadAllText(filePath); // Legge il contenuto del file
            if (jsonLines is null || jsonLines.Length == 0)
            {
                return expenseCategoryList;
            }
            return JsonSerializer.Deserialize<List<ExpenseCategoryAndTypesDTO>>(jsonLines) ?? new List<ExpenseCategoryAndTypesDTO>();
        }

        public static async Task<List<ExpenseCategoryAndTypesDTO>> ReadExpenseCategoryListFromFileAsync()
        {
            List<ExpenseCategoryAndTypesDTO> expenseCategoryList = new List<ExpenseCategoryAndTypesDTO>();
            string filePath = Path.Combine(FileSystem.AppDataDirectory, AppConstants.ExpenseCategoryListFileName);
            if (!File.Exists(filePath))
            {
                return new List<ExpenseCategoryAndTypesDTO>();
            }
            string jsonLines = await File.ReadAllTextAsync(filePath); // Legge il contenuto del file
            if (jsonLines is null || jsonLines.Length == 0)
            {
                return expenseCategoryList;
            }
            return JsonSerializer.Deserialize<List<ExpenseCategoryAndTypesDTO>>(jsonLines) ?? new List<ExpenseCategoryAndTypesDTO>();
        }

        public static void UpdateExpenseListIntoFile(List<ExpenseM> expenseList)
        {
            DeleteExpenseStorageFile();
            string filePath = Path.Combine(FileSystem.AppDataDirectory, AppConstants.ExpenseListFileName);
            foreach (var expense in expenseList)
            {
                File.AppendAllText(filePath, JsonSerializer.Serialize(expense) + Environment.NewLine);
            }
        }

        public static void UpdateExpenseCategoryListIntoFile(List<ExpenseCategoryM> expenseCategoryList)
        {
            DeleteExpenseStorageFile();
            string filePath = Path.Combine(FileSystem.AppDataDirectory, AppConstants.ExpenseCategoryListFileName);
            foreach (var expenseCategory in expenseCategoryList)
            {
                File.AppendAllText(filePath, JsonSerializer.Serialize(expenseCategory) + Environment.NewLine);
            }
        }
    }
}

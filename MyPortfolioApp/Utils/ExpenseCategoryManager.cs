using MyPortfolioApp.Models;

namespace MyPortfolioApp.Utils
{
    public static class ExpenseCategoryManager
    {
        private static List<ExpenseCategoryAndTypesDTO> categoryList = new List<ExpenseCategoryAndTypesDTO>();

        public static List<ExpenseCategoryAndTypesDTO> GetCategoryList()
        {
            return categoryList;
        }

        public static async Task LoadAndSaveDefaultCategory()
        {
            categoryList = new List<ExpenseCategoryAndTypesDTO>()
            {
                new ExpenseCategoryAndTypesDTO() { Name = "Fun", ExpenseTypeList = new List<string>(){ "Ristoranti","Bar","Giochi","CeneVarie","Feste","Mare","ExtraFun","Viaggi"} },
                new ExpenseCategoryAndTypesDTO() { Name = "Shop", ExpenseTypeList = new List<string>(){ "TechGadget","AltriGadget","Vestiti" } },
                new ExpenseCategoryAndTypesDTO() { Name = "Regali", ExpenseTypeList = new List<string>(){ "OtherRegali" } },
                new ExpenseCategoryAndTypesDTO() { Name = "Fees", ExpenseTypeList = new List<string>(){ "Postepay","Binance","Commercialista","AmazonPrime" } },
            };
            await SaveCategoryList();
        }

        public static async Task LoadCategoryFromFileListAsync()
        {
            categoryList = await StorageUtils.ReadExpenseCategoryListFromFileAsync();
        }

        public static void LoadCategoryFromFileList()
        {
            categoryList = StorageUtils.ReadExpenseCategoryListFromFile();
        }

        public static async Task SaveCategoryList()
        {
            if (categoryList.Count > 0)
            {
                StorageUtils.DeleteExpenseCategoryStorageFile();
                await StorageUtils.WriteExpenseCategoryListToFile(categoryList);
            }
        }

        internal static async Task DownloadAndSaveCategoryListFromServer()
        {
            categoryList.Clear();
            categoryList = await ApiService.GetCategoriesAndTypesAsync();
            await SaveCategoryList();
        }
    }
}

using MyPortfolioApp.Utils;

namespace MyPortfolioApp
{
    public partial class App : Application
    {
        public App()
        {
            //ApiService.SetStorageValue(Constants.AppConstants.AddExpenseListApi, "http://localhost:5236/api/Expense/addList");
            //ApiService.SetStorageValue(Constants.AppConstants.GetCategoryListApi, "http://localhost:5236/api/ExpenseCategory/categoriesAndTypes");
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
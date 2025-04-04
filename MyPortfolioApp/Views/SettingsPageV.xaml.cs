using MyPortfolioApp.Utils;

namespace MyPortfolioApp.Views;

public partial class SettingsPageV : ContentPage
{
	public SettingsPageV()
	{

		InitializeComponent();
		LoadEndPointValuse();
    }

    private async void LoadEndPointValuse()
    {
        expenseValue.Text = await ApiService.GetStorageValue(Constants.AppConstants.AddExpenseListApi);
        categoryValue.Text = await ApiService.GetStorageValue(Constants.AppConstants.GetCategoryListApi);
    }

    private async void EditExpenseEndPoint(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Expense endpoint", "Inserire l'API URL per caricare le spese", initialValue: expenseValue.Text);
        if (result != null)
        {
            ApiService.SetStorageValue(Constants.AppConstants.AddExpenseListApi, result);
            expenseValue.Text=result;
        }
    }

    private async void EditCategoryEndPoint(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Category endpoint", "Inserire l'API URL per scaricare le categorie", initialValue: categoryValue.Text);
        if (result != null)
        {
            ApiService.SetStorageValue(Constants.AppConstants.GetCategoryListApi, result);
            categoryValue.Text = result;
        }

    }
}
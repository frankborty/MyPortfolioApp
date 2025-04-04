using MyPortfolioApp.ViewModels;

namespace MyPortfolioApp.Views;

public partial class NewExpensePageV : ContentPage
{
    private ExpenseVM _expenseVM;
    public NewExpensePageV()
    {
        _expenseVM = new ExpenseVM();
        BindingContext = _expenseVM;
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
         _expenseVM.LoadCategoryList();
    }
}
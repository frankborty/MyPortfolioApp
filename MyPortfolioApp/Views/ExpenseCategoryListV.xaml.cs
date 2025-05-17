using MyPortfolioApp.ViewModels;
using System.ComponentModel;

namespace MyPortfolioApp.Views;

public partial class ExpenseCategoryListV : ContentPage, INotifyPropertyChanged
{
    public ExpenseCategoryListV()
    {
        InitializeComponent();
        BindingContext = new ExpenseCategoryListVM();
    }




}
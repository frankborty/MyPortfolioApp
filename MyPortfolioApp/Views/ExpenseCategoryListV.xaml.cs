using MyPortfolioApp.Models;
using MyPortfolioApp.Utils;
using MyPortfolioApp.ViewModels;
using System.Collections.ObjectModel;
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
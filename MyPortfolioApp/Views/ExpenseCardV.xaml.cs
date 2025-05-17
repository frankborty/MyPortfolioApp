using MyPortfolioApp.Models;

namespace MyPortfolioApp.Views;

public partial class ExpenseCardV : ContentView
{
    public ExpenseCardV()
    {
        InitializeComponent();
    }

    private void UploadButtonClicked(object sender, EventArgs e)
    {
        (Parent.Parent.Parent as StoredExpenseListV)?.UploadExpense(this.BindingContext as ExpenseM);
    }

    private async void DeleteButtonClicked(object sender, EventArgs e)
    {
        bool answer = await App.Current!.Windows[0].Page!.DisplayAlert("Cancellazione spesa", "Vuoi cancellare la spesa?", "Yes", "No");
        if (answer)
        {
            (Parent.Parent.Parent as StoredExpenseListV)?.DeleteExpense(this.BindingContext as ExpenseM);
        }
    }
}
using MyPortfolioApp.Models;
using MyPortfolioApp.Utils;
using System.Collections.ObjectModel;

namespace MyPortfolioApp.Views;

public partial class StoredExpenseListV : ContentPage
{
    public ObservableCollection<ExpenseM> ExpenseList { get; set; }
    public StoredExpenseListV()
    {
        ExpenseList = new ObservableCollection<ExpenseM>(StorageUtils.ReadExpenseListFromFile());
        InitializeComponent();
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Rileggi i dati dal file
        var expensesFromFile = StorageUtils.ReadExpenseListFromFile();

        ReloadExpenseList();
    }

    private void ReloadExpenseList()
    {
        base.OnAppearing();

        // Rileggi i dati dal file
        var expensesFromFile = StorageUtils.ReadExpenseListFromFile();

        // Aggiorna la ObservableCollection
        ExpenseList.Clear();
        foreach (var expense in expensesFromFile)
        {
            ExpenseList.Add(expense);
        }
    }

    internal async void UploadExpense(ExpenseM? expense)
    {
        if (expense is null)
        {
            return;
        }
        //carico la spesa
        try
        {
            await ApiService.UploadExpenseList(new List<ExpenseM>() { expense });
            await App.Current!.Windows[0].Page!.DisplayAlert("Successo", "Spesa caricata correttamente", "OK");
            DeleteExpense(expense);
        }
        catch (Exception ex)
        {
            await App.Current!.Windows[0].Page!.DisplayAlert("Errore", $"{ex.Message}", "OK");
        }
    }

    internal void DeleteExpense(ExpenseM? expenseToDelete)
    {
        if (expenseToDelete is null)
        {
            return;
        }
        //cancello la spesa
        ExpenseList.Remove(expenseToDelete);
        StorageUtils.DeleteExpenseStorageFile();
        foreach (var expense in ExpenseList)
        {
            StorageUtils.WriteExpenseToFile(expense);
        }
    }

    private async void UploadAllSpese(object sender, EventArgs e)
    {
        try
        {
            await ApiService.UploadExpenseList(ExpenseList.ToList());
            for (int i = 0; i < ExpenseList.Count;)
            {
                DeleteExpense(ExpenseList.ElementAt(i));
            }

        }
        catch (Exception ex)
        {
            await App.Current!.Windows[0].Page!.DisplayAlert("Errore", $"{ex.Message}", "OK");
            return;
        }

        await App.Current!.Windows[0].Page!.DisplayAlert("Successo", "Caricamento completato", "OK");

    }
}
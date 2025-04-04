using MyPortfolioApp.Models;
using MyPortfolioApp.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MyPortfolioApp.ViewModels
{
    class ExpenseCategoryListVM : INotifyPropertyChanged
    {
        public ICommand DownloadCategoyListCommand { get; }
        public ICommand UseDefaultCategoryListCommand { get; }


        private ObservableCollection<ExpenseCategoryAndTypesDTO> _expenseCategoryList = new ObservableCollection<ExpenseCategoryAndTypesDTO>();
        public ObservableCollection<ExpenseCategoryAndTypesDTO> ExpenseCategoryList
        {
            get => _expenseCategoryList;
            set
            {
                _expenseCategoryList = value;
                OnPropertyChanged(nameof(ExpenseCategoryList));
            }
        }

        public ExpenseCategoryListVM()
        {
            var storedCategoryList = ExpenseCategoryManager.GetCategoryList();
            if (storedCategoryList.Count == 0)
            {
                //ExpenseCategoryManager.LoadDefaultCategory();
                storedCategoryList = ExpenseCategoryManager.GetCategoryList();
            }
            ExpenseCategoryList = new ObservableCollection<ExpenseCategoryAndTypesDTO>(storedCategoryList);
            DownloadCategoyListCommand = new Command(async () => await DownloadCategoyList());
            UseDefaultCategoryListCommand = new Command(async () => await UseDefaultCategoryList());
        }

        private async Task DownloadCategoyList()
        {
            bool answer = await App.Current!.Windows[0].Page!.DisplayAlert("Update category list", "Vuoi scaricare le categorie dal server?", "Yes", "No");
            if (answer)
            {
                await ExpenseCategoryManager.DownloadAndSaveCategoryListFromServer();
                ExpenseCategoryList.Clear();
                foreach (var expenseCategory in ExpenseCategoryManager.GetCategoryList())
                {
                    ExpenseCategoryList.Add(expenseCategory);
                }
            }
        }

        private async Task UseDefaultCategoryList()
        {
            bool answer = await App.Current!.Windows[0].Page!.DisplayAlert("Update category list", "Vuoi ripristinare le categorie di default?", "Yes", "No");
            if (answer)
            {
                await ExpenseCategoryManager.LoadAndSaveDefaultCategory(); // Simula un'attesa (es. chiamata API)
                ExpenseCategoryList.Clear();
                foreach (var expenseCategory in ExpenseCategoryManager.GetCategoryList())
                {
                    ExpenseCategoryList.Add(expenseCategory);
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

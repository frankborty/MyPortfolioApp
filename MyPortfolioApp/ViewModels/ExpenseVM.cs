using MyPortfolioApp.Models;
using MyPortfolioApp.Utils;
using System.ComponentModel;
using System.Windows.Input;

namespace MyPortfolioApp.ViewModels
{
    public class ExpenseVM : INotifyPropertyChanged
    {
        public ICommand SaveCommand { get; }
        private ExpenseM _expense;

        public string Description
        {
            get => _expense.Description;
            set
            {
                if (_expense.Description != value)
                {
                    _expense.Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string ExpenseType
        {
            get => _expense.ExpenseType;
            set
            {
                if (_expense.ExpenseType != value && value is not null)
                {
                    _expense.ExpenseType = value;
                    OnPropertyChanged(nameof(ExpenseType));
                }
            }
        }

        private ExpenseCategoryAndTypesDTO _category = new ExpenseCategoryAndTypesDTO();
        public ExpenseCategoryAndTypesDTO Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    if (value != null)
                    {
                        ExpenseType = _category.ExpenseTypeList[0];
                        ExpenseTypeList = _category.ExpenseTypeList;
                    }
                    OnPropertyChanged(nameof(Category));
                }
            }
        }



        public decimal Amount
        {
            get => _expense.Amount;
            set
            {
                if (_expense.Amount != value)
                {
                    _expense.Amount = value;
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }

        public DateTime Date
        {
            get => _expense.Date;
            set
            {
                if (_expense.Date != value)
                {
                    _expense.Date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        public string Note
        {
            get => _expense.Note;
            set
            {
                if (_expense.Note != value)
                {
                    _expense.Note = value;
                    OnPropertyChanged(nameof(Note));
                }
            }
        }


        private List<ExpenseCategoryAndTypesDTO> _expenseCategoryList = new List<ExpenseCategoryAndTypesDTO>();
        public List<ExpenseCategoryAndTypesDTO> ExpenseCategoryList
        {
            get => _expenseCategoryList;
            set
            {
                if (_expenseCategoryList != value)
                {
                    _expenseCategoryList = value;
                    OnPropertyChanged(nameof(ExpenseCategoryList));
                }
            }
        }

        private List<string> _expenseTypeList = new List<string>();
        public List<string> ExpenseTypeList
        {
            get => _expenseTypeList;
            set
            {
                if (_expenseTypeList != value)
                {
                    _expenseTypeList = value;
                    OnPropertyChanged(nameof(ExpenseTypeList));
                }
            }
        }

        public ExpenseVM()
        {
            
            _expense = new ExpenseM();
            LoadCategoryList();
            
            SaveCommand = new Command(async () => await CheckAndSave());
        }

        private async Task CheckAndSave()
        {
            // Logica di salvataggio
            try
            {
                GeneralUtils.CheckExpense(_expense); // Immagina una logica di salvataggio
                StorageUtils.WriteExpenseToFile(_expense);
                await App.Current!.Windows[0].Page!.DisplayAlert("Successo", "Spesa salvata correttamente!", "OK");
                ResetExpense();
            }
            catch (Exception ex)
            {
                await App.Current!.Windows[0].Page!.DisplayAlert("Errore", "Si è verificato un errore durante il salvataggio: " + ex.Message, "OK");
            }
        }

        private void ResetExpense()
        {
            _expense = new ExpenseM() { Description = "Descrizione di esempio" };
            Description = _expense.Description;
            Amount = 10;
            Date = DateTime.Now;
            if (_expenseCategoryList.Count > 0)
            {
                Category = ExpenseCategoryList[0];
                if (_category.ExpenseTypeList.Count > 0)
                {
                    ExpenseType = Category.ExpenseTypeList[0] ?? string.Empty;
                }
                else
                {
                    ExpenseType = string.Empty;
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void LoadCategoryList()
        {
            ExpenseCategoryList = ExpenseCategoryManager.GetCategoryList();
            if (ExpenseCategoryList.Count > 0 && _expense is not null)
            {
                _expenseTypeList = _expenseCategoryList[0].ExpenseTypeList;
                _category = _expenseCategoryList[0];
                _expense.ExpenseType = _category.ExpenseTypeList[0];
            }
        }
    }
}

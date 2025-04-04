using MyPortfolioApp.Models;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyPortfolioApp.Utils
{
    internal static class ApiService
    {
        public static void SetStorageValue(string key, string value)
        {
            SecureStorage.SetAsync(key, value);
        }

        public static async Task<string> GetStorageValue(string key)
        {
            return await SecureStorage.GetAsync(key) ?? string.Empty;
        }


        public static async Task<List<ExpenseCategoryAndTypesDTO>> GetCategoriesAndTypesAsync()
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                string apiUrl = await GetStorageValue(Constants.AppConstants.GetCategoryListApi);
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode(); // Lancia un'eccezione se la risposta non è OK (200-299)

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<List<ExpenseCategoryAndTypesDTO>>(jsonResponse, options) ?? new List<ExpenseCategoryAndTypesDTO>();
            }
            catch (Exception ex)
            {
                await App.Current!.Windows[0].Page!.DisplayAlert("Errore", $"{ex.Message}", "OK");
                return new List<ExpenseCategoryAndTypesDTO>();
            }
        }




        public static async Task UploadExpenseList(List<ExpenseM> expenseListToUpload)
        {
            HttpClient _httpClient = new HttpClient();
            string apiUrl = await GetStorageValue(Constants.AppConstants.AddExpenseListApi);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, expenseListToUpload);
            response.EnsureSuccessStatusCode(); // Lancia un'eccezione se la risposta non è OK (200-299)
            return;
            
        }
    }
}

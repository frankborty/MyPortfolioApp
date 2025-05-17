using Microsoft.Extensions.Logging;
using MyPortfolioApp.Utils;

namespace MyPortfolioApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            ExpenseCategoryManager.LoadCategoryFromFileList();

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

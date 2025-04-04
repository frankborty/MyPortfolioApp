namespace MyPortfolioApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            darkModeToggle.IsToggled = (Application.Current!.UserAppTheme != AppTheme.Light);
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            Application.Current!.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
        }
    }
}

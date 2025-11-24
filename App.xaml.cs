using KajsaJosefssonCV.Views;
using System.Windows;

namespace KajsaJosefssonCV
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Skapar och visar MainView manuellt
            var window = new MainView();
            window.Show();
        }
    }
}
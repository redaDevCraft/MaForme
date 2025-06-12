using System.Windows;
using MaForme.Services;
using MaForme.ViewModels;
using MaForme.Views;

namespace MaForme
{
    public partial class App : Application
    {
        private IFormStorageService _formStorageService;
        private TemplatesViewModel _templatesViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize services
            _formStorageService = new FormStorageService();

            // Initialize viewmodels with dependencies
            _templatesViewModel = new TemplatesViewModel(_formStorageService);

            // Create and show main window, inject viewmodel
            var mainWindow = new MainWindow
            {
                DataContext = _templatesViewModel
            };
            mainWindow.Show();
        }
    }
}

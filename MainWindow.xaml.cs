using System.Windows;
using System.Windows.Controls;
using MaForme.Views;

namespace MaForme
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new DashboardView()); // Default view
            PageTitle.Text = "Dashboard";
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DashboardView());
            PageTitle.Text = "Dashboard";
        }

        private void TemplatesButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to TemplateSelector instead of old TemplatesView
            MainFrame.Navigate(new TemplateSelector());
            PageTitle.Text = "Templates";
        }

        private void SavedFormsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SavedFormsView());
            PageTitle.Text = "Saved Forms";
        }
    }
}

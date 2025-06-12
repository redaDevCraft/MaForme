using System.Windows;
using System.Windows.Controls;

namespace MaForme
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Views.DashboardView()); // Default view
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.DashboardView());
            PageTitle.Text = "Dashboard";
        }

        private void TemplatesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.TemplatesView());
            PageTitle.Text = "Templates";
        }

        private void SavedFormsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.SavedFormsView());
            PageTitle.Text = "Saved Forms";
        }

      
    }
}

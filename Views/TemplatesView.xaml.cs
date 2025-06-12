using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaForme.Views
{
    /// <summary>
    /// Interaction logic for TemplatesView.xaml
    /// </summary>
    public partial class TemplatesView : UserControl
    {
        public TemplatesView()
        {
            InitializeComponent();
        }

        private void OpenPersonalInfoTemplate_Click(object sender, RoutedEventArgs e)
        {
            var navigationService = NavigationService.GetNavigationService(this);
            navigationService?.Navigate(new Views.Templates.PersonalInformationForme());
        }
    }
}

using System.Windows.Controls;
using MaForme.Services;
using MaForme.ViewModels;

namespace MaForme.Views
{
    public partial class TemplateSelector : UserControl
    {
        public TemplateSelector()
        {
            InitializeComponent();

            // Set DataContext here to pass required dependencies
            DataContext = new TemplatesViewModel(new FormStorageService());
        }
    }
}

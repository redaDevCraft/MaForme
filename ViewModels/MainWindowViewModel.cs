using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MaForme.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowDashboardCommand { get; }
        public ICommand ShowTemplatesCommand { get; }
        public ICommand ShowSavedFormsCommand { get; }

        public MainWindowViewModel()
        {
            ShowDashboardCommand = new RelayCommand(parameter => CurrentView = new Views.DashboardView(), parameter => true);
            ShowTemplatesCommand = new RelayCommand(
                parameter => CurrentView = new Views.TemplatesView(),
                parameter => true
            );
            ShowSavedFormsCommand = new RelayCommand(parameter => CurrentView = new Views.SavedFormsView(), parameter => true);

            // Default view
            CurrentView = new Views.DashboardView();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

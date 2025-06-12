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
            ShowDashboardCommand = new RelayCommand(() => CurrentView = new Views.DashboardView(), () => true);
            ShowTemplatesCommand = new RelayCommand(() => CurrentView = new Views.TemplatesView(), () => true);
            ShowSavedFormsCommand = new RelayCommand(() => CurrentView = new Views.SavedFormsView(), () => true);

            // Default view
            CurrentView = new Views.DashboardView();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

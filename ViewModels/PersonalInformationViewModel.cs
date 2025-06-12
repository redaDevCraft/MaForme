using MaForme.Models;
using MaForme.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MaForme.ViewModels
{
    public class PersonalInformationViewModel : INotifyPropertyChanged
    {
        private PersonalInformation _person;
        public PersonalInformation Person
        {
            get => _person;
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommand { get; }

        public PersonalInformationViewModel()
        {
            Person = LocalStorageService.Load();
            SubmitCommand = new RelayCommand(_ => SavePersonalInfo());
        }

        private void SavePersonalInfo()
        {
            LocalStorageService.Save(Person);
            MessageBox.Show("Personal information saved locally.");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

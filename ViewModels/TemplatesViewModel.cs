using System.Collections.ObjectModel;
using MaForme.Models;
using System.Windows.Input;
using System.Linq;
using System;
using MvvmHelpers;
using MaForme.Services;

namespace MaForme.ViewModels
{
    public class TemplatesViewModel : BaseViewModel
    {
        // List of available templates
        public ObservableCollection<FormTemplate> Templates { get; set; }

        // List of user-created instances
        public ObservableCollection<FormInstance> Instances { get; set; }

        // Selected template in UI
        private FormTemplate _selectedTemplate = null!;
        public FormTemplate SelectedTemplate
        {
            get => _selectedTemplate;
            set
            {
                _selectedTemplate = value;
                OnPropertyChanged(nameof(SelectedTemplate));
            }
        }

        // Selected instance in UI
        private FormInstance _selectedInstance = null!;
        public FormInstance SelectedInstance
        {
            get => _selectedInstance;
            set
            {
                _selectedInstance = value;
                OnPropertyChanged(nameof(SelectedInstance));
            }
        }

        // Command to create a new instance from selected template
        public ICommand CreateInstanceCommand { get; set; }

        // Command to load an existing instance
        public ICommand LoadInstanceCommand { get; set; }

        // Command to save an instance
        public ICommand SaveInstanceCommand { get; set; }

        private readonly IFormStorageService _storageService;

        public TemplatesViewModel(IFormStorageService storageService)
        {
            _storageService = storageService;

            Templates = new ObservableCollection<FormTemplate>(LoadTemplates());
            Instances = new ObservableCollection<FormInstance>(_storageService.LoadAllInstances());

            // Fix for CS1593 and CS8625: Pass a valid object parameter to match the delegate signatures
            CreateInstanceCommand = new RelayCommand(CreateInstance, CanCreateInstance);
            LoadInstanceCommand = new RelayCommand(LoadInstance, CanLoadInstance);
            SaveInstanceCommand = new RelayCommand(SaveInstance, CanSaveInstance);
        }

        private IEnumerable<FormTemplate> LoadTemplates()
        {
            // Hardcoded example templates - replace with dynamic loading if needed
            return new List<FormTemplate>
                    {
                        new FormTemplate("Invoice", "Invoice form template"),
                        new FormTemplate("Report", "Report form template"),
                        new FormTemplate("Survey", "Survey form template")
                    };
        }

        private bool CanCreateInstance(object parameter) => SelectedTemplate != null;

        private void CreateInstance(object parameter)
        {
            string newInstanceName = $"New {SelectedTemplate.Name} - {DateTime.Now:yyyyMMddHHmmss}";
            var newInstance = new FormInstance(SelectedTemplate.Id, newInstanceName);

            Instances.Add(newInstance);
            SelectedInstance = newInstance;

            // Optionally open form editor window here
        }

        private bool CanLoadInstance(object parameter) => SelectedInstance != null;

        private void LoadInstance(object parameter)
        {
            // Load instance data and open editor
            // Implementation depends on your form editing UI
        }

        private bool CanSaveInstance(object parameter) => SelectedInstance != null;

        private void SaveInstance(object parameter)
        {
            _storageService.SaveInstance(SelectedInstance);
        }
    }
}

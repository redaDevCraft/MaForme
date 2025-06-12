using MaForme.Helpers;
using MaForme.Models;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MaForme.Views.Templates
{
    public partial class PersonalInformationForme : Page
    {
        public PersonalInformationForme()
        {
            InitializeComponent();
        }

        private void ExportToPdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var info = new PersonalInformation
                {
                    FullName = FullNameTextBox.Text.Trim(),
                    Email = EmailTextBox.Text.Trim(),
                    Phone = PhoneTextBox.Text.Trim()
                };

                if (string.IsNullOrWhiteSpace(info.FullName) ||
                    string.IsNullOrWhiteSpace(info.Email) ||
                    string.IsNullOrWhiteSpace(info.Phone))
                {
                    MessageBox.Show("Please fill in all required fields.", "Incomplete Form", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = $"{info.FullName}_PersonalInformation.pdf"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    // Static content that always appears on the document
                    var staticTexts = new[]
                    {
                        "Company Name: XYZ Corporation",
                        "Form Title: Personal Information Form",
                        $"Date: {DateTime.Now:dd/MM/yyyy}",
                        "Signature: _________________________"
                    };

                    PdfExporter.ExportForm(info, saveFileDialog.FileName, "Personal Information", staticTexts);
                    MessageBox.Show("PDF Exported Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during export:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

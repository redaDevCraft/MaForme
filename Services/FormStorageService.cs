using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MaForme.Models;

namespace MaForme.Services
{
    public class FormStorageService : IFormStorageService
    {
        private readonly string _storageFolder;

        public FormStorageService()
        {
            _storageFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MaForme", "FormInstances");
            Directory.CreateDirectory(_storageFolder);
        }

        public void SaveInstance(FormInstance instance)
        {
            string filePath = GetFilePath(instance.InstanceId);
            string json = JsonSerializer.Serialize(instance, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public FormInstance LoadInstance(Guid instanceId)
        {
            string filePath = GetFilePath(instanceId);
            if (!File.Exists(filePath))
                return null;

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<FormInstance>(json);
        }

        public IEnumerable<FormInstance> LoadAllInstances()
        {
            var files = Directory.GetFiles(_storageFolder, "*.json");
            foreach (var file in files)
            {
                string json = File.ReadAllText(file);
                if (JsonSerializer.Deserialize<FormInstance>(json) is FormInstance instance)
                    yield return instance;
            }
        }

        public void DeleteInstance(Guid instanceId)
        {
            string filePath = GetFilePath(instanceId);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        private string GetFilePath(Guid instanceId) => Path.Combine(_storageFolder, $"{instanceId}.json");
    }
}

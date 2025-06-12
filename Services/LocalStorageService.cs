using MaForme.Models;
using System.IO;
using System.Text.Json;

namespace MaForme.Services
{
    public static class LocalStorageService
    {
        private static readonly string FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MaForme", "personal_information.json");

        public static void Save(PersonalInformation info)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            string json = JsonSerializer.Serialize(info);
            File.WriteAllText(FilePath, json);
        }

        public static PersonalInformation Load()
        {
            if (!File.Exists(FilePath)) return new PersonalInformation();
            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<PersonalInformation>(json);
        }
    }
}

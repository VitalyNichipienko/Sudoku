using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Core.Data
{
    public enum SaveType
    {
        Template,
        Progress
    }

    public class SaveManager : MonoBehaviour
    {
        public void SaveTemplate(GeneratedFieldSaveData templateSave, string fileName)
        {
            SaveToFile(templateSave, fileName, SaveType.Template);
        }

        public void SaveProgress(ProgressFieldSaveData progressSave, string fileName)
        {
            SaveToFile(progressSave, fileName, SaveType.Progress);
        }

        public T LoadFromFile<T>(string fileName)
        {
            string filePath = Path.Combine(Constants.SaveDirectory, fileName + Constants.FileExtension);
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            Debug.LogWarning("File not found: " + filePath);
            return default;
        }

        public List<string> GetSaveFiles(SaveType saveType)
        {
            if (!Directory.Exists(Constants.SaveDirectory))
            {
                Directory.CreateDirectory(Constants.SaveDirectory);
            }

            string searchPattern = saveType == SaveType.Template ? "*" + Constants.TemplateFileSuffix + Constants.FileExtension : "*" + Constants.ProgressFileSuffix + Constants.FileExtension;
            string[] files = Directory.GetFiles(Constants.SaveDirectory, searchPattern);
            List<string> saveFiles = new List<string>();

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                saveFiles.Add(fileName);
            }

            return saveFiles;
        }

        private void SaveToFile<T>(T data, string fileName, SaveType saveType)
        {
            string filePath = Path.Combine(Constants.SaveDirectory, fileName + GetFileSuffix(saveType) + Constants.FileExtension);
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        private string GetFileSuffix(SaveType saveType)
        {
            return saveType == SaveType.Template ? Constants.TemplateFileSuffix : Constants.ProgressFileSuffix;
        }
    }
}
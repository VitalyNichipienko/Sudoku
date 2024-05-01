using System;
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
        public const string FileExtension = ".json";
        public const string TemplateFileSuffix = "_template";
        public const string ProgressFileSuffix = "_progress";
        
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
            string filePath = Path.Combine(Application.persistentDataPath, fileName + FileExtension);
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
            if (!Directory.Exists(Application.persistentDataPath))
            {
                Directory.CreateDirectory(Application.persistentDataPath);
            }

            string searchPattern = saveType == SaveType.Template ? "*" + TemplateFileSuffix + FileExtension : "*" + ProgressFileSuffix + FileExtension;
            string[] files = Directory.GetFiles(Application.persistentDataPath, searchPattern);
            List<string> saveFiles = new List<string>();

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                saveFiles.Add(fileName);
            }

            return saveFiles;
        }

        public void DeleteSaveFile(string fileName, SaveType saveType)
        {
            string filePath = Path.Combine(Application.persistentDataPath, fileName + FileExtension);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Debug.Log("Save file deleted: " + filePath);
            }
            else
            {
                Debug.LogWarning("Save file not found: " + filePath);
            }
        }
        
        private void SaveToFile<T>(T data, string fileName, SaveType saveType)
        {
            string filePath = Path.Combine(Application.persistentDataPath, fileName + GetFileSuffix(saveType) + FileExtension);
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        private string GetFileSuffix(SaveType saveType)
        {
            return saveType == SaveType.Template ? TemplateFileSuffix : ProgressFileSuffix;
        }
    }
}